using Godot;

public partial class Mapa1 : Node2D
{

	private TileMap mapa;
	private int capaTierra = 1;
	private int capaSemillas = 3;
	private Jugador jugador;

	public override void _Ready()
	{
		mapa = GetNode<TileMap>("TileMap");
		jugador = (Jugador)GetNode<CharacterBody2D>("Jugador");
	}

	public override void _Process(double delta)
	{
		Vector2I characterPosition = (Vector2I)jugador.GetCharacterPosition();


		if (Input.IsActionJustPressed("plow"))
		{
			Vector2I local = mapa.LocalToMap(characterPosition);
			int hojaSpritesID = 12;
			Vector2I coordTierra = new Vector2I(1, 1);
			mapa.SetCell(capaTierra, local, hojaSpritesID, coordTierra);
		}

		if (Input.IsActionJustPressed("seeds")) 
		{
			Vector2I local = mapa.LocalToMap(characterPosition);
			TileData tileData = mapa.GetCellTileData(capaTierra, local);
			Variant semillas = false;

            if (tileData != null)
			{
                semillas = tileData.GetCustomData("puede_semillas");
            }
			else
			{
                GD.Print("No se puede plantar ahi"); //Convertir a popup
            }
			int plantasID = 1;
			Vector2I coordSemilla = new Vector2I(1, 0);
			
            if (((bool)semillas) == true)
            {
                mapa.SetCell(capaSemillas, local, plantasID, coordSemilla);
            }
		}
	}
}
