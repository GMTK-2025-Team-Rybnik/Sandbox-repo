using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export]
    public float Gravity;
    [Export]
    public float MovementSpeed;
    [Export]
    public float JumpSpeed;
    [Export]
    public float JumpDurationFrames;

    private Vector2 JumpVelocity;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Vector2.Zero;
        if (!IsOnFloor())
        {
            Velocity += new Vector2(0f, Gravity);
        }

        if (IsOnFloor())
        {
            JumpVelocity = Vector2.Zero;
        }
        else
        {
            JumpVelocity -= new Vector2(0, JumpSpeed) / JumpDurationFrames;
        }

        if (Input.IsActionPressed("move_left"))
        {
            Velocity -= new Vector2(MovementSpeed, 0);
        }
        if (Input.IsActionPressed("move_right"))
        {
            Velocity += new Vector2(MovementSpeed, 0);
        }
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            JumpVelocity += new Vector2(0, JumpSpeed);
        }

        Velocity -= JumpVelocity;
        MoveAndSlide();
    }



}
