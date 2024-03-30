using Godot;

public partial class Jugador : CharacterBody2D
{
    public const float Speed = 300.0f;
    private AnimationPlayer animacion;
    private Vector2 vector;
    private Sprite2D jugador;
    private Sprite2D spriteAccion;

    public override void _Ready()
    {
        // Obtener referencias a los nodos
        animacion = GetNode<AnimationPlayer>("Animacion");
        jugador = GetNode<Sprite2D>("SpriteJugador");

        // Inicia la animación Idle cuando el juego comienza
        animacion.Play("IdleAbajo");

        //Ocultar raton
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        /* Mueve el personaje dependiendo de la tecla 
         * (configuración en el propio proyecto de Godot)
         * y aplica la animacion correspondiente
         */
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.IsActionPressed("move_down")) //S
        {
            verticalInput += 1;

            if (animacion.CurrentAnimation != "Abajo")
            {
                animacion.Play("Abajo");
            }

            vector = new(0, 1);
        }
        else if (animacion.CurrentAnimation == "Abajo")
        {
            animacion.Play("IdleAbajo");
        }

        if (Input.IsActionPressed("move_up")) //W
        {
            verticalInput -= 1;

            if (animacion.CurrentAnimation != "Arriba")
            {
                animacion.Play("Arriba");
            }

            vector = new(0, -1);
        }
        else if (animacion.CurrentAnimation == "Arriba")
        {
            animacion.Play("IdleArriba");
        }

        if (Input.IsActionPressed("move_right") ||
            Input.IsActionPressed("move_right") && Input.IsActionPressed("move_up") ||
            Input.IsActionPressed("move_right") && Input.IsActionPressed("move_down")) //D
        {
            horizontalInput += 1;

            if (animacion.CurrentAnimation != "Derecha")
            {
                animacion.Play("Derecha");
            }

            vector = new(1, 0);
        }
        else if (animacion.CurrentAnimation == "Derecha")
        {
            animacion.Play("IdleDer");
        }

        if (Input.IsActionPressed("move_left") || 
            (Input.IsActionPressed("move_left") && Input.IsActionPressed("move_up")) ||
            (Input.IsActionPressed("move_left") && Input.IsActionPressed("move_down"))) //A
        {
            horizontalInput -= 1;

            if (animacion.CurrentAnimation != "Izquierda")
            {
                animacion.Play("Izquierda");
            }

            vector = new(-1, 0);
        }
        else if (animacion.CurrentAnimation == "Izquierda")
        {
            animacion.Play("IdleIzq");
        }

        Vector2 direction = new(horizontalInput, verticalInput);

        if (direction != Vector2.Zero)
        {
            velocity = direction.Normalized() * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();

        if (Input.IsActionJustPressed("plow") && (animacion.CurrentAnimation == "IdleAbajo"))
        {
            animacion.Play("ararAbajo");
        }
        else if (Input.IsActionJustPressed("plow") && (animacion.CurrentAnimation == "IdleArriba"))
        {
            animacion.Play("ararArriba");
        }
        else if (Input.IsActionJustPressed("plow") && (animacion.CurrentAnimation == "IdleDer"))
        {
            animacion.Play("ararDer");
        }
        else if (Input.IsActionJustPressed("plow") && (animacion.CurrentAnimation == "IdleIzq"))
        {
            animacion.Play("ararIzq");
        }
    }

    public void _on_animation_player_animation_finished(string anim)
    {
        if (anim.Equals("ararAbajo"))
        {
            animacion.Play("IdleAbajo");
        }
    }

}
