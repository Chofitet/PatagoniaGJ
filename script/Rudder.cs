using Godot;

public partial class Rudder : CharacterBody3D
{
    [Export] private float _rotationSpeed = 1.0f;
    [Export] private double _smoothFactor = 5.0f;
    [Export] private double _targetRotationZ = 0.0f;


    public override void _PhysicsProcess(double delta)
    {
        Controller(delta);
    }

    private void Controller(double delta)
    {
        ApplySteeringRotation(delta);
    }

    private void ApplySteeringRotation(double delta)
    {
        float horizontal = Input.GetAxis("ui_right", "ui_left");

        _targetRotationZ += horizontal * _rotationSpeed * delta;

        double currentRotationZ = Mathf.Lerp(Rotation.Z, _targetRotationZ, _smoothFactor * delta);

        Rotation = new Vector3(Rotation.X, Rotation.Y, (float)currentRotationZ);
    }
}
