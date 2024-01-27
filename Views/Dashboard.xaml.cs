using proyecto.Models;

namespace proyecto.Views;

public partial class Dashboard : ContentPage
{
    private Cliente cliente;
    public Dashboard(Cliente cliente)
	{
        InitializeComponent();
        this.cliente = cliente; // Almacena el cliente recibido en la variable de instancia
        lblUsuario.Text = "Bienvenido/a "+cliente.GetFullName();

    }

    private void btnInsertarVehiculo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InsertarVehiculo(cliente));
    }

    private void btnCita_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InsertarCita(cliente));
    }

    private void btnActualizarCliente_Clicked(object sender, EventArgs e)
    {

    }

    private void btnVerCitas_Clicked(object sender, EventArgs e)
    {

    }
    protected override bool OnBackButtonPressed()
    {
        // Bloquear la pulsaci�n del bot�n de retroceso
        return true;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Login());

        // Limpiar los campos de usuario y contrase�a
        if (Application.Current.MainPage is NavigationPage navigationPage)
        {
            var loginPage = navigationPage.RootPage as Login;
            loginPage?.LimpiarCampos();
        }
    }
    
}