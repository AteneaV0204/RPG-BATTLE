using Godot;

public partial class Mapa1 : Node2D
{

    private TileMap mapa;
    private int capaTierra = 1;
    private Jugador jugador;

    public override void _Ready()
    {
        mapa = GetNode<TileMap>("TileMap");
        jugador = (Jugador)GetNode<CharacterBody2D>("Jugador");
    }

    public override void _Process(double delta)
    {
        Vector2 characterPosition = jugador.GetCharacterPosition();


        if (Input.IsActionJustPressed("plow"))
        {
            var local = mapa.LocalToMap(characterPosition);
            GD.Print("Posicion: " + local);
            var hojaSpritesID = 12;
            Vector2I coordTierra = new Vector2I(1, 1);
            mapa.SetCell(capaTierra, local, hojaSpritesID, coordTierra);
        }
    }
}
