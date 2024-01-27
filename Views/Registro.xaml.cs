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
            // Verificar que los campos obligatorios estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                DisplayAlert("ERROR", "Por favor, complete todos los campos obligatorios.", "CERRAR");
                return; // Salir del método si falta algún campo obligatorio
            }

            // Verificar que las contraseñas coincidan
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                DisplayAlert("ERROR", "Las contraseñas no coinciden. Por favor, vuelva a ingresarlas.", "CERRAR");
                return; // Salir del método si las contraseñas no coinciden
            }

            // Verificar que el correo electrónico contenga un símbolo "@"
            if (!txtCorreo.Text.Contains("@"))
            {
                DisplayAlert("ERROR", "Ingrese un correo electrónico válido.", "CERRAR");
                return; // Salir del método si el correo no es válido
            }

            // Resto del código para enviar la solicitud de registro
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
            DisplayAlert("ÉXITO", "Registro exitoso", "CERRAR");

            // Navegar a la página de inicio de sesión
            Navigation.PushAsync(new Login());
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error si hay algún problema durante el registro
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}
