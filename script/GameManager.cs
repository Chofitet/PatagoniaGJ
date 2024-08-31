using Godot;

public partial class GameManager : Node
{
    [Export] private CharacterBody3D _rudder = null;
    [Export] private Camera3D _firstScreen = null;

    public override void _PhysicsProcess(double delta)
    {
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        _firstScreen.Rotation = new Vector3(_firstScreen.Rotation.X, _firstScreen.Rotation.Y, -_rudder.Rotation.Z);
    }
}
