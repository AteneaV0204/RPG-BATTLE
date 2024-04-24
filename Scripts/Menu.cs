using Godot;
using System;

public partial class Menu : CanvasLayer
{
    private Control main;
    private Control ajustes;
    private OptionButton button;

    private const string fullscreen = "Pantalla completa";
    private const string max = "Maximizado";
    private const string min = "Minimizado";
    private static readonly string[] ARRAY_MODO_VENTANA = { fullscreen, max, min };

    public override void _Ready()
	{
		main = GetNode<Control>("Main");
        ajustes = GetNode<Control>("Ajustes");
        button = GetNode<OptionButton>("OptionButton");
        AgregarItems();
        button.ItemSelected += OnWindowModeSelected;
    }

	public void _OnBtnJugarPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Mapa1.tscn");
    }

    public void _OnBtnAjustesPressed()
    {
        main.Visible = false;
        ajustes.Visible = true;
    }

    public void _OnBtnAtrasPressed()
    {
        main.Visible = true;
        ajustes.Visible = false;
    }

    public void _OnBtnSalirPressed()
    {
        GetTree().Quit();
    }

    private void AgregarItems()
    {
        foreach (string item in ARRAY_MODO_VENTANA)
        {
            button.AddItem(item);
        }
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
