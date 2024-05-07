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
	private bool crecimiento = false;

	public override void _Ready()
	{
		mapa = GetNode<TileMap>("TileMap");
		jugador = (Jugador)GetNode<CharacterBody2D>("Jugador");
		timer = GetNode<Timer>("Timer");
	}

	public override void _Process(double delta)
	{
		characterPosition = (Vector2I)jugador.GetCharacterPosition();
		Vector2I local;

		if (Input.IsActionJustPressed("plow"))
		{
			local = mapa.LocalToMap(characterPosition);
			int hojaSpritesID = 12;
			Vector2I coordTierra = new(1, 1);
			mapa.SetCell(capaTierra, local, hojaSpritesID, coordTierra);
		}

		if (Input.IsActionJustPressed("seeds")) 
		{
            timer.Start();
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
			
			if (((bool)semillas) == true && crecimiento)
			{
                //mapa.SetCell(capaSemillas, local, plantasID, cordSemilla);
				crecimiento = false;
                CicloPlantas(local, 0, cordSemilla, 4);
				timer.Stop();
                timer.Start();
                GD.Print("Planta");
            }
		}
	}

	/// <summary>
	/// Funcion para manejar el ciclo de crecimiento de las plantas
	/// </summary>
	/// <param name="posPlanta">Posicion de la planta en el tilemap</param>
	/// <param name="fasePlanta">Fase actual de la planta en el tileset</param>
	/// <param name="cordSemilla">Coordenada de la primera fase de la planta en el atlas</param>
	/// <param name="finalPlanta">Los tilesets que hay hasta la ultima fase de la planta</param>
	private void CicloPlantas(Vector2I posPlanta, int fasePlanta, Vector2I cordSemilla, int finalPlanta)
	{
        //mapa.SetCell(capaSemillas, posPlanta, plantasID, cordSemilla);

        for (int i = fasePlanta; i <= finalPlanta; i++)
        {
            mapa.SetCell(capaSemillas, posPlanta, plantasID, cordSemilla);
            Vector2I nuevaFase = new((cordSemilla.X + 1), cordSemilla.Y); //Cambia el aspecto de la planta para que crezca
            mapa.SetCell(capaSemillas, posPlanta, plantasID, nuevaFase);

            if (fasePlanta == finalPlanta) //Si la planta ya ha terminado de crecer, para el temportizador y sale del metodo
            {
                timer.Stop();
                return;
            }
        }
        //CicloPlantas(posPlanta, fasePlanta + 1, nuevaFase, finalPlanta);
    }

    private void _OnTimerTimeout()
	{
		crecimiento = true;
		GD.Print("fin");
	}

}
