using Godot;
using System;

public partial class Jugador : CharacterBody2D
{
    public const float Speed = 300.0f;
    private AnimationPlayer animacion;

    public override void _Ready()
    {
        // Obtén una referencia al nodo AnimationPlayer dentro del personaje
        animacion = GetNode<AnimationPlayer>("Animacion");

        // Inicia la animación Idle cuando el juego comienza
        animacion.Play("IdleAbajo");
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

        if (Input.IsActionPressed("move_right")) //D
        {
            horizontalInput += 1;

            if (animacion.CurrentAnimation != "Derecha")
            {
                animacion.Play("Derecha");
            }
        }
        if (Input.IsActionPressed("move_left")) //A
        {
            horizontalInput -= 1;

            if (animacion.CurrentAnimation != "Izquierda")
            {
                animacion.Play("Izquierda");
            }
        }
        if (Input.IsActionPressed("move_down")) //S
        {
            verticalInput += 1;

            if (animacion.CurrentAnimation != "Abajo")
            {
                animacion.Play("Abajo");
            }
        }
        if (Input.IsActionPressed("move_up")) //W
        {
            verticalInput -= 1;

            if (animacion.CurrentAnimation != "Arriba")
            {
                animacion.Play("Arriba");
            }
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

            if (animacion.CurrentAnimation != "IdleAbajo")
            {
                animacion.Play("IdleAbajo");
            }
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
