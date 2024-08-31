using Godot;

public partial class GameManager : Node
{
    [Export] private CharacterBody3D _rudder = null;
    [Export] private WorldScreen _worldScreen = null;

    public override void _PhysicsProcess(double delta)
    {
        _worldScreen.ApplyAccelerationCamera(delta);
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        _worldScreen.ApplyRotationCamera(-_rudder.Rotation.Z);
        //_worldScreen.Rotation = new Vector3(_worldScreen.Rotation.X, _worldScreen.Rotation.Y, -_rudder.Rotation.Z);
    }
}
