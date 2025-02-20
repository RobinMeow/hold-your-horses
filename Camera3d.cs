using Godot;
using System;

public partial class Camera3d : Node3D
{
    [Export(PropertyHint.Range, "0,1")]
    float movespeed = 0.2f;

    [Export(PropertyHint.Range, "0,5")]
    float zoomRange = 3f;

    Vector3 startingVector = Vector3.Zero;

    public override void _Ready()
    {
        startingVector = Transform.Origin;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("move camera up 2D"))
        {
            TranslateObjectLocal(-Transform.Basis.Z * movespeed);
        }
        if (Input.IsActionPressed("move camera down 2D"))
        {
            TranslateObjectLocal(Transform.Basis.Z * movespeed);
        }
        if (Input.IsActionPressed("move camera right 2D"))
        {
            TranslateObjectLocal(Transform.Basis.X * movespeed);
        }
        if (Input.IsActionPressed("move camera left 2D"))
        {
            TranslateObjectLocal(-Transform.Basis.X * movespeed);
        }

        if (Input.IsActionPressed("zoom camera in") && Transform.Origin.Y >= startingVector.Y - zoomRange)
        {
            TranslateObjectLocal(-Transform.Basis.Y * movespeed);
        }
        if (Input.IsActionPressed("zoom camera out") && Transform.Origin.Y <= startingVector.Y)
        {
            TranslateObjectLocal(Transform.Basis.Y * movespeed);
        }
    }
}
