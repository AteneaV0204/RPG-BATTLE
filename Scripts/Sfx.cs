using Godot;

public partial class Sfx : HBoxContainer
{
    private Label numSfx;
    private HSlider volSfx;

    public override void _Ready()
    {
        numSfx = GetNode<Label>("VolNum");
        volSfx = GetNode<HSlider>("VolSfx");
        ValorSlider();
    }

    public void CambiarNumVolumen()
    {
        numSfx.Text = (volSfx.Value * 100).ToString("#.##");
    }

    public void ValorSlider()
    {
        volSfx.Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(2));
        CambiarNumVolumen();
    }

    public void _OnVolMaestroValueChanged(float volumen)
    {
        AudioServer.SetBusVolumeDb(2, Mathf.LinearToDb(volumen));
        CambiarNumVolumen();
    }
}
