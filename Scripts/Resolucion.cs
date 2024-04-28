using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class Resolucion : HBoxContainer
{
	private OptionButton resoluciones;
	private Dictionary<string, Vector2I> resolucionesPantalla = new Dictionary<string, Vector2I>()
	{
		{"720p", new Vector2I(1280, 720)},
		{"1080p HD", new Vector2I(1920, 1080)},
		{"1440p 2K", new Vector2I(2560, 1440)},
		{"2160p 4K", new Vector2I(3840, 2160)},
	};

	public override void _Ready()
	{
		resoluciones = GetNode<OptionButton>("Resoluciones");
		resoluciones.ItemSelected += _OnResolucionSelected;

		AgregarElementos();
	}

	private void AgregarElementos()
	{
		foreach (string resolucion in resolucionesPantalla.Keys) 
		{
			resoluciones.AddItem(resolucion);
		}
	}

	private void _OnResolucionSelected(long index)
	{
		DisplayServer.WindowSetSize(resolucionesPantalla.Values.ElementAt<Vector2I>((int)index));
	}
}
