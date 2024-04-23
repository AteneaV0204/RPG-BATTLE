using Godot;
using System;

public partial class ModoVentana : Control
{
	private OptionButton ventana;
    private const string fullscreen = "Pantalla completa";
    private const string max = "Maximizado";
    private const string min = "Minimizado";
    private static readonly string[] ARRAY_MODO_VENTANA = { fullscreen, max, min };

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		ventana = GetNode<OptionButton>("OptionButton");
		ventana.ItemSelected += OnWindowModeSelected;
	}

    private void OnWindowModeSelected(long index)
    {
        switch (index)
        {
            case 0: //Pantalla completa
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
                break;
            case 1: //Maximizado
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Maximized);
                break;
            case 2: //Minimizado
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Minimized);
                break;

        }
    }
}
