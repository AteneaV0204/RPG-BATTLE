using Godot;

public partial class ModoVentana : Control
{
    public void _OnFullScreenPressed()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
    }
    public void _OnMaximizadoPressed()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Maximized);
    }
    public void _OnVentanaPressed()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
    }
}
