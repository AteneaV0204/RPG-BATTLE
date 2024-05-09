using Godot;

public partial class Menu : CanvasLayer
{
    private Control main;
    private Control ajustes;
    private AudioStreamPlayer2D click;

    public override void _Ready()
    {
        main = GetNode<Control>("Main");
        ajustes = GetNode<Control>("Ajustes");
    }

    /// <summary>
    /// Evento para el boton "Jugar" del menu principal
    /// </summary>
    public void _OnBtnJugarPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Mapa1.tscn");
    }

    /// <summary>
    /// Evento para el boton "Ajustes" del menu principal
    /// </summary>
    public void _OnBtnAjustesPressed()
    {
        main.Visible = false;
        ajustes.Visible = true;
    }

    /// <summary>
    /// Evento para el boton "Atras" del menu de ajustes
    /// </summary>
    public void _OnBtnAtrasPressed()
    {
        main.Visible = true;
        ajustes.Visible = false;
    }

    /// <summary>
    /// Evento para salir del juego
    /// </summary>
    public void _OnBtnSalirPressed()
    {
        GetTree().Quit();
    }
}
