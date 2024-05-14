using Godot;
using System;

public partial class Tienda : StaticBody2D
{
	private Area2D area;
	private Mapa1 mapa;
	private int beneficios;

	public override void _Ready()
	{
		area = GetNode<Area2D>("Area2D");

		area.BodyEntered += _OnTiendaEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/// <summary>
	/// Evento ligado al nodo Area2D
	/// </summary>
	/// <param name="node">Nodo que entra en el area</param>
    public void _OnTiendaEntered(Node2D node)
	{
		if(node.HasMethod("JugadorVender"))
		{
			int trigo = mapa.GetTrigo();

			if(trigo < 0)
			{
				beneficios = trigo * 10;
				mapa.SetTrigo(0);
			}
			else
			{
				GD.Print("No hay trigo para vender");
			}
		}
	}

	public int GetBeneficios()
	{
		return beneficios;
	}
}
