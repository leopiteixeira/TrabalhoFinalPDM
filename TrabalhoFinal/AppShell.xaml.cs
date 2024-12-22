namespace TrabalhoFinal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreditosPage), typeof(CreditosPage));
        }

        private async void Creditos_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreditosPage));
        }
    }
}
