using Godot;

public partial class Maestros : HBoxContainer
{
    private Label numMaestro;
    private HSlider volMaestro;

    public override void _Ready()
    {
        numMaestro = GetNode<Label>("VolNum");
        volMaestro = GetNode<HSlider>("VolMaestro");
        ValorSlider();
    }

    public void CambiarNumVolumen()
    {
        numMaestro.Text = (volMaestro.Value * 100).ToString("#.##");
    }

    public void ValorSlider()
    {
        volMaestro.Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(0));
        CambiarNumVolumen();
    }

    public void _OnVolMaestroValueChanged(float volumen)
    {
        AudioServer.SetBusVolumeDb(0, Mathf.LinearToDb(volumen));
        CambiarNumVolumen();
    }
}