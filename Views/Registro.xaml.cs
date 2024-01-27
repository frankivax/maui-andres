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
            // Verificar que los campos obligatorios est�n llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                DisplayAlert("ERROR", "Por favor, complete todos los campos obligatorios.", "CERRAR");
                return; // Salir del m�todo si falta alg�n campo obligatorio
            }

            // Verificar que las contrase�as coincidan
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                DisplayAlert("ERROR", "Las contrase�as no coinciden. Por favor, vuelva a ingresarlas.", "CERRAR");
                return; // Salir del m�todo si las contrase�as no coinciden
            }

            // Verificar que el correo electr�nico contenga un s�mbolo "@"
            if (!txtCorreo.Text.Contains("@"))
            {
                DisplayAlert("ERROR", "Ingrese un correo electr�nico v�lido.", "CERRAR");
                return; // Salir del m�todo si el correo no es v�lido
            }

            // Resto del c�digo para enviar la solicitud de registro
            WebClient clienteWeb = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("telefono", txtTelefono.Text);
            parametros.Add("direccion", txtDireccion.Text);
            parametros.Add("correo", txtCorreo.Text);
            parametros.Add("password", txtContrasena.Text);
            clienteWeb.UploadValues("http://192.168.100.3/tallerMecanico/post.php", "POST", parametros);

            // Mostrar mensaje de registro exitoso
            DisplayAlert("�XITO", "Registro exitoso", "CERRAR");

            // Navegar a la p�gina de inicio de sesi�n
            Navigation.PushAsync(new Login());
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error si hay alg�n problema durante el registro
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}
