using Godot;

public partial class Musica : HBoxContainer
{
    private Label numMusica;
    private HSlider volMusica;

    public override void _Ready()
    {
        numMusica = GetNode<Label>("VolNum");
        volMusica = GetNode<HSlider>("VolMusica");
        ValorSlider();
    }

    public void CambiarNumVolumen()
    {
        numMusica.Text = (volMusica.Value * 100).ToString("#.##");
    }

    public void ValorSlider()
    {
        volMusica.Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(1));
        CambiarNumVolumen();
    }

    public void _OnVolMaestroValueChanged(float volumen)
    {
        AudioServer.SetBusVolumeDb(1, Mathf.LinearToDb(volumen));
        CambiarNumVolumen();
    }
}
