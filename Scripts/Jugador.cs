using Godot;

public partial class Jugador : CharacterBody2D
{
    public const float Speed = 300.0f;
    private AnimationPlayer animacion;
    private Vector2 direction;
    private Vector2 velocity;
    private Sprite2D jugador;
    private AnimationTree tree;

    public override void _Ready()
    {
        // Obtener referencias a los nodos
        animacion = GetNode<AnimationPlayer>("Animacion");
        jugador = GetNode<Sprite2D>("SpriteJugador");
        tree = GetNode<AnimationTree>("AnimationTree");

        // Inicia la animación Idle cuando el juego comienza
        direction = Vector2.Zero;

        //Ocultar raton
        //Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        ActualizarParametros();
    }

    public override void _PhysicsProcess(double delta)
    {
        velocity = Velocity;

        direction = Input.GetVector("move_left", "move_right", "move_up", "move_down").Normalized();

        if (direction != Vector2.Zero)
        {
            velocity = direction * Speed;
        }
        else
        {
            velocity = Vector2.Zero;
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void ActualizarParametros()
    {
        if(velocity == Vector2.Zero)
        {
            tree.Set("parameters/conditions/idle", true);
            tree.Set("parameters/conditions/is_moving", false);
        } 
        else
        {
            tree.Set("parameters/conditions/idle", false);
            tree.Set("parameters/conditions/is_moving", true);
        }

        if (Input.IsActionJustPressed("plow"))
        {
            tree.Set("parameters/conditions/arar", true);
        }
        else
        {
            tree.Set("parameters/conditions/arar", false);
        }

        if(direction != Vector2.Zero)
        {
            tree.Set("parameters/Idle/blend_position", direction);
            tree.Set("parameters/Walk/blend_position", direction);
            tree.Set("parameters/Arar/blend_position", direction);
        }
        
    }

}