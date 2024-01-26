using proyecto.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;

namespace proyecto.Views;

public partial class InsertarCita : ContentPage
{
    private Cliente cliente;
    private const string Url = "http://192.168.86.30/tallerMecanico/postTaller.php";
    private readonly HttpClient clienteWeb = new HttpClient();
    private ObservableCollection<Taller> talleres;
    private ObservableCollection<Vehiculo> vehiculos;

    public InsertarCita(Cliente cliente)
	{
		InitializeComponent();
        ObtenerTalleres();
        ObtenerVehiculos(cliente);
        this.cliente = cliente;

    }

    public async void ObtenerTalleres()
    {
        var content = await clienteWeb.GetStringAsync(Url);
        List<Taller> mostrarTalleres = JsonConvert.DeserializeObject<List<Taller>>(content);
        talleres = new ObservableCollection<Taller>(mostrarTalleres);
  
        pkTalleres.ItemsSource = talleres.Select(t => t.nombreTaller).ToList();
    }

    public async void ObtenerVehiculos(Cliente cliente)
    {
     
        string urlVehiculos = $"http://192.168.86.30/tallerMecanico/postVehiculo.php?clienteId={cliente.clienteId}";

        var contentVehiculos = await clienteWeb.GetStringAsync(urlVehiculos);
        List<Vehiculo> mostrarVehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(contentVehiculos);
        vehiculos = new ObservableCollection<Vehiculo>(mostrarVehiculos);

        pkVehiculos.ItemsSource = vehiculos.Select(v => v.modelo).ToList();
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
        try
        {
    

            WebClient clienteWeb = new WebClient();
            int tallerId = talleres[pkTalleres.SelectedIndex].tallerId;
            int vehiculoId = vehiculos[pkVehiculos.SelectedIndex].vehiculoId;
            string fechaFormateada = dpFecha.Date.ToString("yyyy-MM-dd");

            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("fecha", fechaFormateada);
            parametros.Add("hora", tpHora.Time.ToString());
            parametros.Add("problema", txtProblema.Text);
            parametros.Add("tallerId", tallerId.ToString());
            parametros.Add("vehiculoId", vehiculoId.ToString());
            clienteWeb.UploadValues("http://192.168.86.30/tallerMecanico/postCita.php", "POST", parametros);
            Navigation.PushAsync(new Dashboard(cliente));
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}