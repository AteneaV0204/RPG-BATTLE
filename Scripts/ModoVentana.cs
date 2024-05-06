using Godot;

public partial class ModoVentana : Control
{
    private OptionButton ventana;
    private readonly string[] modos = { "Ventana completa", "Maximizado", "Minimizado"};

    public override void _Ready()
    {
        ventana = GetNode<OptionButton>("ModoVentana");
        ventana.ItemSelected += _OnModoSelected;

        AgregarElementos();
    }

    private void AgregarElementos()
    {
        foreach (string modo in modos)
        {
            ventana.AddItem(modo);
        }
    }

    private void _OnModoSelected(long index)
    {
        switch (index) {
            case 0: //Pantalla completa
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
                break;
            case 1:
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Maximized);
                break;
            case 2:
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
                break;
        }
    }
}
