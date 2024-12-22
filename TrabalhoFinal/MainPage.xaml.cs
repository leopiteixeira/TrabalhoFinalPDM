using TrabalhoFinal.Models;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace TrabalhoFinal
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async Task<bool> SolicitarPermissoesAsync()
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status == PermissionStatus.Granted;
        }

        private async void ObterLocalizacao_Clicked(object sender, EventArgs e)
        {
            if (await SolicitarPermissoesAsync())
            {
                try
                {
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium
                    });

                    if (location != null)
                    {
                        CoordenadasLabel.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";
                    }
                    else
                    {
                        CoordenadasLabel.Text = "Não foi possível obter a localização.";
                    }
                }
                catch (Exception ex)
                {
                    CoordenadasLabel.Text = $"Erro: {ex.Message}";
                }
            }
            else
            {
                CoordenadasLabel.Text = "Permissão de localização negada.";
            }
        }

        private void AdicionarLivro_Clicked(object sender, EventArgs e)
        {
            var livro = new Livro
            {
                NomeLivro = NomeLivro.Text,
                NomeAutor = NomeAutor.Text,
                EmailAutor = EmailAutor.Text,
                ISBN = ISBN.Text
            };
            App.LivroRepo.SaveLivro(livro);
            NomeLivro.Text = NomeAutor.Text = EmailAutor.Text = ISBN.Text = string.Empty;
            ListaLivros.ItemsSource = App.LivroRepo.GetLivros();
        }

        private void ListarLivros_Clicked(object sender, EventArgs e)
        {
            ListaLivros.ItemsSource = App.LivroRepo.GetLivros();
        }

        private void ExcluirLivro_Clicked(object sender, EventArgs e)
        {
            var livro = (sender as Button).BindingContext as Livro;
            App.LivroRepo.DeleteLivro(livro.Id);
            ListaLivros.ItemsSource = App.LivroRepo.GetLivros();
        }

        private async void MostrarLocalizacao_Clicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLocationAsync();
            if (location != null)
            {
                await DisplayAlert("Localização", $"Lat: {location.Latitude}, Lng: {location.Longitude}", "OK");
            }
        }


    }

}
