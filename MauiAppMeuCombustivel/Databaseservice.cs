using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppMeuCombustivel
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        public async Task InitAsync()
        {
            if (_db != null) return;

            var path = Path.Combine(
                FileSystem.AppDataDirectory,
                "combustivel.db3");

            _db = new SQLiteAsyncConnection(path);
            await _db.CreateTableAsync<HistoricoCalculo>();
        }

        public Task SalvarCalculoAsync(HistoricoCalculo h)
            => _db.InsertAsync(h);

        public Task<List<HistoricoCalculo>> GetHistoricoAsync()
            => _db.Table<HistoricoCalculo>()
                  .OrderByDescending(h => h.Data)
                  .ToListAsync();
    }
}
