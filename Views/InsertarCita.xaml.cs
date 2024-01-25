using proyecto.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace proyecto.Views;

public partial class InsertarCita : ContentPage
{
   
    private const string Url = "http://192.168.86.30/tallerMecanico/postTaller.php";
    private readonly HttpClient clienteWeb = new HttpClient();
    private ObservableCollection<Taller> talleres;

    public InsertarCita()
	{
		InitializeComponent();
        ObtenerTalleres();
    }

    public async void ObtenerTalleres()
    {
        var content = await clienteWeb.GetStringAsync(Url);
        List<Taller> mostrarTalleres = JsonConvert.DeserializeObject<List<Taller>>(content);
        talleres = new ObservableCollection<Taller>(mostrarTalleres);
  
        pkTalleres.ItemsSource = talleres.Select(t => t.nombreTaller).ToList();
    }

    private async void btnTomarFoto_Clicked(object sender, EventArgs e)
    {
        var foto = await MediaPicker.CapturePhotoAsync();
        if(foto!=null)
        {
            var memoriaStream = await foto.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(() => memoriaStream);
        }
    }

    private async void btnSeleccionarFoto_Clicked(object sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();
        if (foto != null)
        {
            var memoriaStream = await foto.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(() => memoriaStream);
        }
    }

    private void btnAgendar_Clicked(object sender, EventArgs e)
    {

    }
}