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

            // Verificar que las contraseñas coincidan
            if (contrasena != confirmarContrasena)
            {
                DisplayAlert("ERROR", "Las contraseñas no coinciden.", "CERRAR");
                return; // Salir de la función si las contraseñas no coinciden
            }

            // Construir la URL según la lógica deseada
            string url = "http://192.168.100.3/tallerMecanico/post.php?clienteId=" + clienteId + "&nombre=" + nombre + "&apellido="
                         + apellido + "&telefono=" + telefono + "&direccion=" + direccion + "&correo=" + correo;

            // Agregar la contraseña solo si no está vacía
            if (!string.IsNullOrWhiteSpace(contrasena))
            {
                url += "&password=" + contrasena;
            }

            WebClient clienteWeb = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            // Realizar la solicitud de actualización con la URL modificada
            clienteWeb.UploadValues(url, "PUT", parametros);

  
  

            // Mostrar alerta de actualización exitosa
            DisplayAlert("Éxito", "La información se actualizó correctamente.", "OK");

            // Navegar a la página de Dashboard
            Navigation.PushAsync(new Dashboard(cliente));
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}