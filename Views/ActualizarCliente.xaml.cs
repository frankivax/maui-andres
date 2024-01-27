using proyecto.Models;
using System.Net;

namespace proyecto.Views;

public partial class ActualizarCliente : ContentPage
{
    private Cliente cliente;
    public ActualizarCliente(Cliente cliente)
	{
		InitializeComponent();
        this.cliente = cliente; // Almacena el cliente recibido en la variable de instancia
        txtClienteId.Text = cliente.clienteId.ToString();
        txtNombre.Text = cliente.nombre;
        txtApellido.Text = cliente.apellido;
        txtTelefono.Text = cliente.telefono;
        txtDireccion.Text = cliente.direccion;
        txtCorreo.Text = cliente.correo;


    }


    private void btnActualizarCliente_Clicked(object sender, EventArgs e)
    {
        try
        {
            string clienteId = txtClienteId.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;
            string confirmarContrasena = txtConfirmarContrasena.Text;

            // Verificar que las contrase�as coincidan
            if (contrasena != confirmarContrasena)
            {
                DisplayAlert("ERROR", "Las contrase�as no coinciden.", "CERRAR");
                return; // Salir de la funci�n si las contrase�as no coinciden
            }

            // Construir la URL seg�n la l�gica deseada
            string url = "http://192.168.100.3/tallerMecanico/post.php?clienteId=" + clienteId + "&nombre=" + nombre + "&apellido="
                         + apellido + "&telefono=" + telefono + "&direccion=" + direccion + "&correo=" + correo;

            // Agregar la contrase�a solo si no est� vac�a
            if (!string.IsNullOrWhiteSpace(contrasena))
            {
                url += "&password=" + contrasena;
            }

            WebClient clienteWeb = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            // Realizar la solicitud de actualizaci�n con la URL modificada
            clienteWeb.UploadValues(url, "PUT", parametros);

  
  

            // Mostrar alerta de actualizaci�n exitosa
            DisplayAlert("�xito", "La informaci�n se actualiz� correctamente.", "OK");

            // Navegar a la p�gina de Dashboard
            Navigation.PushAsync(new Dashboard(cliente));
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}