using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppMeuCombustivel
{
    internal class HistoricoCalculo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public double PrecoEtanol { get; set; }
        public double PrecoGasolina { get; set; }
        public string Resultado { get; set; }
        public DateTime Data { get; set; }
    }
}
