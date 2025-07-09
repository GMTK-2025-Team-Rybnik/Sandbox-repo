using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export]
    public Vector2 Gravity;
    [Export]
    public Vector2 MovementSpeed;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Vector2.Zero;
        if (!IsOnFloor())
        {
            Velocity += Gravity;
        }

        if (Input.IsActionPressed("move_left"))
        {
            Velocity -= MovementSpeed;
        }
        if (Input.IsActionPressed("move_right"))
        {
            Velocity += MovementSpeed;
        }
        if (Input.IsActionPressed("jump"))
        {
            // Velocity += MovementSpeed;
        }

        MoveAndSlide();
    }



}
