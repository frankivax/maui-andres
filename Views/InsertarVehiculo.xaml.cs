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
            // Validar que los campos obligatorios no est�n vac�os
            if (string.IsNullOrWhiteSpace(txtPlaca.Text) || string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) || string.IsNullOrWhiteSpace(txtAnio.Text))
            {
                DisplayAlert("ERROR", "Todos los campos son obligatorios.", "CERRAR");
                return;
            }

            WebClient clienteWeb = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("placa", txtPlaca.Text);
            parametros.Add("marca", txtMarca.Text);
            parametros.Add("modelo", txtModelo.Text);
            parametros.Add("anio", txtAnio.Text);
            parametros.Add("clienteId", txtClienteId.Text);

            clienteWeb.UploadValues("http://192.168.100.3/tallerMecanico/postVehiculo.php", "POST", parametros);
            Navigation.PushAsync(new Dashboard(cliente));

            // Mostrar mensaje de �xito
            DisplayAlert("�xito", "Veh�culo registrado correctamente.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}