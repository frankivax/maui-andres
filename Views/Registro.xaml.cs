using System.Net;

namespace proyecto.Views;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }

    private void btnRegistro_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient clienteWeb = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("telefono", txtTelefono.Text);
            parametros.Add("direccion", txtDireccion.Text);
            parametros.Add("correo", txtCorreo.Text);
            parametros.Add("password", txtContrasena.Text);
            clienteWeb.UploadValues("http://192.168.100.3/tallerMecanico/post.php", "POST", parametros);
            Navigation.PushAsync(new Login());
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}
