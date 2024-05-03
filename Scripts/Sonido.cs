using Godot;
using System;

public partial class Sonido : HBoxContainer
{
	private Label numMaestro;
	private HSlider volMaestro;
	private int busIndex = 0;

	public override void _Ready()
	{
		numMaestro = GetNode<Label>("VolNum");
		volMaestro = GetNode<HSlider>("VolMaestro");
		CambiarNumVolumen();

    }

	public void CambiarNumVolumen()
	{
		numMaestro.Text = volMaestro.Value.ToString();
	}

    public void _OnVolMaestroValueChanged(float volumen)
	{

	}
}

public enum BusesAudio
{
	Master,
	Musica,
	Sfx
} 
