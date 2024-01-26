using proyecto.Models;
using System.Net;

namespace proyecto.Views;

public partial class InsertarVehiculo : ContentPage
{
    private Cliente cliente;
    public InsertarVehiculo(Cliente cliente)
	{
		InitializeComponent();
        this.cliente = cliente; // Almacena el cliente recibido en la variable de instancia
        txtClienteId.Text = cliente.clienteId.ToString(); // 
    }

    private void btnAgregarVehiculo_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient clienteWeb = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("placa", txtPlaca.Text);
            parametros.Add("marca", txtMarca.Text);
            parametros.Add("modelo", txtModelo.Text);
            parametros.Add("anio", txtAnio.Text);
            parametros.Add("clienteId", txtClienteId.Text);
            clienteWeb.UploadValues("http://192.168.100.3/tallerMecanico/postVehiculo.php", "POST", parametros);
            Navigation.PushAsync(new Dashboard(cliente));
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}