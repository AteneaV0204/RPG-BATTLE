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
	private int trigo;
	private int monedas;
    private AudioStreamPlayer2D cosechar;
	private Label contador;
	private Label monedero;

    public override void _Ready()
	{
		mapa = GetNode<TileMap>("TileMap");
		jugador = (Jugador)GetNode<CharacterBody2D>("Jugador");
        cosechar = GetNode<AudioStreamPlayer2D>("Cosechar");
        contador = GetNode<Label>("Jugador/Camera2D/Contador");
        monedero = GetNode<Label>("Jugador/Camera2D/Monedero");
		trigo = 0;
    }

	public override void _Process(double delta)
	{
		characterPosition = (Vector2I)jugador.GetCharacterPosition();
		Vector2I local = mapa.LocalToMap(characterPosition); ;

		if (Input.IsActionJustPressed("plow"))
		{
			int hojaSpritesID = 12;
			Vector2I coordTierra = new(1, 1);
			mapa.SetCell(capaTierra, local, hojaSpritesID, coordTierra);
		}

		if (Input.IsActionJustPressed("seeds")) 
		{
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
                mapa.SetCell(capaSemillas, local, plantasID, cordSemilla);
                CicloPlantas(local, cordSemilla, 3);
			}
		}

		if (Input.IsActionJustPressed("crop"))
		{
			Vector2I fase1 = new(4, 0);

			if(mapa.GetCellAtlasCoords(capaSemillas, local) == fase1)
			{
				mapa.EraseCell(capaSemillas, local);
				trigo++;
				contador.Text = "= " + trigo;
				cosechar.Play();

            }
            else
			{
				GD.Print("Debes plantar trigo para cosecharlo");
			}
		}
	}

	/// <summary>
	/// Funcion para manejar el ciclo de crecimiento de las plantas
	/// </summary>
	/// <param name="posPlanta">Posicion de la planta en el tilemap</param>
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

		monedero.Text = jugador.GetMonedas().ToString();
    }

	public int GetTrigo()
	{
		return trigo;
	}

	public void SetTrigo(int trigo)
	{
		this.trigo = trigo;
	}

}
