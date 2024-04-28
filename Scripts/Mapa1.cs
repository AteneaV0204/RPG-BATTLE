using Godot;

public partial class Mapa1 : Node2D
{

	private TileMap mapa;
	private int capaTierra = 1;
	private int capaSemillas = 3;
	private int plantasID = 1;
    private Jugador jugador;
	private Timer timer;
	private Vector2I characterPosition;


    public override void _Ready()
	{
		mapa = GetNode<TileMap>("TileMap");
		jugador = (Jugador)GetNode<CharacterBody2D>("Jugador");

        //Crear timer para el crecimiento de las plantas
        timer = new()
        {
            WaitTime = 0.1
        };
		timer.Timeout += TimerTimeout;
		AddChild(timer);
    }

	public override void _Process(double delta)
	{
		characterPosition = (Vector2I)jugador.GetCharacterPosition();
		Vector2I local;

		if (Input.IsActionJustPressed("plow"))
		{
			local = mapa.LocalToMap(characterPosition);
			int hojaSpritesID = 12;
			Vector2I coordTierra = new Vector2I(1, 1);
			mapa.SetCell(capaTierra, local, hojaSpritesID, coordTierra);
		}

		if (Input.IsActionJustPressed("seeds")) 
		{
			local = mapa.LocalToMap(characterPosition);
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
			Vector2I cordSemilla = new(1, 0);
			
            if (((bool)semillas) == true)
            {
				GD.Print("semillas");
				CicloPlantas(local, 0, cordSemilla, 3);
                GD.Print("CicloPlantas");
            }
		}
	}

	/// <summary>
	/// Funcion para manejar el ciclo de crecimiento de las plantas
	/// </summary>
	/// <param name="posPlanta">Posicion de la planta en el tilemap</param>
	/// <param name="fasePlanta">Fase actual de la planta en el tileset</param>
	/// <param name="cordSemilla">Coordenada de la primera fase de la planta</param>
	/// <param name="finalPlanta">Los tilesets que hay hasta la ultima fase de la planta</param>
	private async void CicloPlantas(Vector2I posPlanta, int fasePlanta, Vector2I cordSemilla, int finalPlanta)
	{
        mapa.SetCell(capaSemillas, posPlanta, plantasID, cordSemilla);
		GD.Print("Setcell");
		await ToSignal(timer, "timeout");
		GD.Print("await");
    }

    private void TimerTimeout()
    {
		GD.Print("timer");
        characterPosition = (Vector2I)jugador.GetCharacterPosition();

        Vector2I cordSemilla = new(1, 0);
        CicloPlantas(characterPosition, 0, cordSemilla, 3);
    }


}
