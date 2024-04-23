using Godot;
using System;

public partial class Ajustes : Control
{
	private Button salir;

    public override void _Ready()
	{
		salir = GetNode<Button>("Salir");
	}

	private void _SalirPressed()
	{
		
	}

	//public override void _Process(double delta)
	//{
	//}
}
