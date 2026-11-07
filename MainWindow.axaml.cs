
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private bool saludoAlternativo = false;

    private const string MensajeInicial =
        "Completa tus datos y presiona Presentarme.";

    public MainWindow()
    {
        InitializeComponent();
    }

    private bool ValidarDatos(
        out string nombre,
        out string apellido,
        out int edad)
    {
        nombre = TxtNombre.Text?.Trim() ?? "";
        apellido = TxtApellido.Text?.Trim() ?? "";
        edad = 0;

        if (string.IsNullOrWhiteSpace(nombre))
        {
            TxtResultado.Text = "Advertencia: ingresa tu nombre.";
            TxtNombre.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            TxtResultado.Text = "Advertencia: ingresa tu apellido.";
            TxtApellido.Focus();
            return false;
        }

        if (!int.TryParse(TxtEdad.Text?.Trim(), out edad))
        {
            TxtResultado.Text = "Advertencia: ingresa una edad numérica entera.";
            TxtEdad.Focus();
            return false;
        }

        if (edad <= 0)
        {
            TxtResultado.Text = "Advertencia: la edad debe ser mayor que cero.";
            TxtEdad.Focus();
            return false;
        }

        return true;
    }

    private void MostrarPresentacion()
    {
        if (!ValidarDatos(out string nombre,
                         out string apellido,
                         out int edad))
        {
            return;
        }

        if (saludoAlternativo)
        {
            TxtResultado.Text =
                $"¡Mucho gusto! Soy {nombre} {apellido}, " +
                $"tengo {edad} años y me alegra presentarme.";
        }
        else
        {
            TxtResultado.Text =
                $"¡Hola! Mi nombre es {nombre} {apellido}, " +
                $"tengo {edad} años y estoy aprendiendo " +
                "a desarrollar interfaces gráficas con C#.";
        }
    }

    private void BtnPresentarme_Click(
        object? sender, RoutedEventArgs e)
    {
        MostrarPresentacion();
    }

    private void BtnLimpiar_Click(
        object? sender, RoutedEventArgs e)
    {
        TxtNombre.Text = "";
        TxtApellido.Text = "";
        TxtEdad.Text = "";

        saludoAlternativo = false;
        TxtResultado.Text = MensajeInicial;

        TxtNombre.Focus();
    }

    private void BtnCambiarSaludo_Click(
        object? sender, RoutedEventArgs e)
    {
        if (!ValidarDatos(out _, out _, out _))
        {
            return;
        }

        saludoAlternativo = !saludoAlternativo;
        MostrarPresentacion();
    }
}
