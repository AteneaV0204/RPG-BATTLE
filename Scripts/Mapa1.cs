using Godot;
using System.Threading.Tasks;

public partial class Mapa1 : Node2D
{
	private TileMap mapa;
	private int capaTierra = 1;
	private int capaSemillas = 3;
	private int plantasID = 1;
	private Jugador jugador;
	private Vector2I characterPosition;
	private Global global;
	private Vector2I plantaFinal = new(4, 0);

	public override void _Ready()
	{
		mapa = GetNode<TileMap>("TileMap");
		jugador = (Jugador)GetNode<CharacterBody2D>("Jugador");
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
<<<<<<< HEAD
                CicloPlantas(local, cordSemilla, 3);
            }
		}

		if (Input.IsActionJustPressed("crop"))
		{
			local = mapa.LocalToMap(characterPosition);

			if (mapa.GetCellAtlasCoords(capaSemillas, local) == plantaFinal)
			{
				mapa.EraseCell(capaSemillas, local);
                global.Trigo = +1;

            }
			else
			{
				GD.Print("No hay plantas que cosechar aqui"); //popup
=======
                mapa.SetCell(capaSemillas, local, plantasID, cordSemilla);
                CicloPlantas(local, cordSemilla, 3);
>>>>>>> nose
			}
		}
	}

	/// <summary>
	/// Funcion para manejar el ciclo de crecimiento de las plantas
	/// </summary>
	/// <param name="posPlanta">Posicion de la planta en el tilemap</param>
<<<<<<< HEAD
	/// <param name="fasePlanta">Fase actual de la planta en el tileset</param>
	/// <param name="cordSemilla">Coordenada de la primera fase de la planta en el atlas</param>
	/// <param name="finalPlanta">Los tilesets que hay hasta la ultima fase de la planta</param>
	private async void CicloPlantas(Vector2I posPlanta, Vector2I cordSemilla, int finalPlanta)
	{
        mapa.SetCell(capaSemillas, posPlanta, plantasID, cordSemilla);

		for (int i = 0; i <= finalPlanta; i++)
		{
			await Task.Delay(1000);
			Vector2I nuevaFase = new((cordSemilla.X + i), cordSemilla.Y); //Cambia el aspecto de la planta para que crezca
			mapa.SetCell(capaSemillas, posPlanta, plantasID, nuevaFase);
		}
	}
=======
	/// <param name="cordSemilla">Coordenada de la primera fase de la planta</param>
	/// <param name="finalPlanta">Los tilesets que hay hasta la ultima fase de la planta</param>
	private async void CicloPlantas(Vector2I posPlanta, Vector2I cordSemilla, int finalPlanta)
	{
		mapa.SetCell(capaSemillas, posPlanta, plantasID, cordSemilla);

        for (int i = 0; i <= finalPlanta; i++)
        {
            await Task.Delay(1000);
            Vector2I nuevaFase = new((cordSemilla.X + i), cordSemilla.Y); //Cambia el aspecto de la planta para que crezca
            mapa.SetCell(capaSemillas, posPlanta, plantasID, nuevaFase);
        }
    }
>>>>>>> nose

}
