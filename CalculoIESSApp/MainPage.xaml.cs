namespace CalculoIESSApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    [Obsolete]
    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        // 1. Validar que no existan campos vacíos
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtEdad.Text) ||
            string.IsNullOrWhiteSpace(txtSalario.Text))
        {
            await DisplayAlert("Atención", "Por favor, llene todos los campos del formulario.", "OK");
            return;
        }

        // 2. Validar que la Edad sea un número entero válido
        if (!int.TryParse(txtEdad.Text.Trim(), out int edad) || edad <= 0)
        {
            await DisplayAlert("Error de Entrada", "Ingrese una edad válida (número entero positivo).", "OK");
            return;
        }

        // 3. Validar que el Salario sea un número decimal válido
        if (!decimal.TryParse(txtSalario.Text.Trim(), out decimal salario) || salario <= 0)
        {
            await DisplayAlert("Error de Entrada", "Ingrese un salario válido mayor a 0.", "OK");
            return;
        }

        // 4. Cálculo del aporte al IESS (9.45%)
        decimal aporte = salario * 0.0945m;

        // 5. Construcción del mensaje con saltos de línea (\n)
        string mensaje = $"Bienvenido “{txtNombre.Text.Trim()} {txtApellido.Text.Trim()}”\n" +
                         $"Tienes “{edad}” años\n" +
                         $"Tu aporte mensual es “${aporte:F2}”";

        // 6. Mostrar Alerta
        await DisplayAlert("Resultado", mensaje, "Aceptar");
    }
}