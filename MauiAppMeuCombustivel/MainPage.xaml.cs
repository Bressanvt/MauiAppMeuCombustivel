namespace MauiAppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _db;

        // Injetar via construtor
        public MainPage(DatabaseService db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void Button_Clicked(
            object sender, EventArgs e)
        {
            try
            {
                double etanol = Convert.ToDouble(txt_etanol.Text);
                double gasolina = Convert.ToDouble(txt_gasolina.Text);

                string msg = etanol <= (gasolina * 0.7)
                    ? "O etanol está compensando"
                    : "A gasolina está compensando";

                // Inicializar e salvar no banco
                await _db.InitAsync();
                await _db.SalvarCalculoAsync(new HistoricoCalculo
                {
                    PrecoEtanol = etanol,
                    PrecoGasolina = gasolina,
                    Resultado = msg,
                    Data = DateTime.Now
                });

                await DisplayAlert("Calculado", msg, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }//Fecha metodo
    }//Fecha class
}//Fecha namespace
