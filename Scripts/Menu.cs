using Godot;
using System;

public partial class Menu : CanvasLayer
{
	private Control main;
	private Control ajustes;

	public override void _Ready()
	{
		main = GetNode<Control>("Main");
		ajustes = GetNode<Control>("Ajustes");
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
}
