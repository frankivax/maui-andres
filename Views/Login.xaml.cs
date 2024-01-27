using Newtonsoft.Json;
using proyecto.Models;
using System.Collections.ObjectModel;

namespace proyecto.Views;

public partial class Login : ContentPage
{
    private const string Url = "http://192.168.100.3/tallerMecanico/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Cliente> cli;
    public Login()
    {
        InitializeComponent();
        Obtener();
    }

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Cliente> mostrarCli = JsonConvert.DeserializeObject<List<Cliente>>(content);
        cli = new ObservableCollection<Cliente>(mostrarCli);
    }

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
       
        string usuario = txtCorreo.Text;
        string contrasena = txtContrasena.Text;

        var usuarioEncontrado = cli.FirstOrDefault(u => u.correo == usuario && u.password == contrasena);

        if (usuarioEncontrado != null)
        {
            Navigation.PushAsync(new Dashboard(usuarioEncontrado));
        }
        else
        {
            DisplayAlert("ALERTA", "Usuario/Contraseña incorrectos", "Cancel");
        }
    }

    private void btnAcercaDe_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Informacion del Desarrollador", "Nombre: Andres Diaz \nCurso: 8vo\nParalelo: A", "Cancel");
    }

    private void btnRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registro());
    }

    public void LimpiarCampos()
    {
        txtCorreo.Text = string.Empty;
        txtContrasena.Text = string.Empty;
    }
}