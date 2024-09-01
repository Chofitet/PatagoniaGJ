using Godot;

public partial class BoatRotation : Node3D
{
	[Export] private float _rotationSpeed = 0.15f;
	[Export] private double _smoothFactor = 5.0f;
	[Export] private double _targetRotationZ = 0.0f;

	private int _ejeX = 1;
	private float _scaledDelta = 0.0f;
	private float _timer = 0.0f;

	private const float _TIME_SCALE = 1.0f;
	private const float _TIME_BETWEEN_BULLETS = 0.015F;

	public override void _Process(double delta)
	{
        _timer += (float)delta;
		_scaledDelta = (float)delta * _TIME_SCALE;
		
	}

    public override void _PhysicsProcess(double delta)
    {
		ApplyForceMovement(delta);
    }

    public void ApplyForceMovement(double delta)
	{
		if (_scaledDelta != 0.0f && _timer <= _TIME_BETWEEN_BULLETS)
		{
			_targetRotationZ += _ejeX * _rotationSpeed * delta;
			
			double currentRotationZ = Mathf.Lerp(Rotation.Z, _targetRotationZ, _smoothFactor * delta);
			
			Rotation = new Vector3(Rotation.X, Rotation.Y, (float)currentRotationZ);

			_timer = 0.0f;
			_ejeX *= -1;
		}
	}
}
