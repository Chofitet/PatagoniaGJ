using Godot;

public partial class WorldScreen : Node3D
{
	[Export] private Node3D _cameraController = null;

	[Export] private float _accelerate = 0.8f;

	public void ApplyAccelerationCamera(double delta)
	{
		Vector3 moveCamera = Vector3.Forward * _accelerate * (float)delta;
		_cameraController.Translate(moveCamera);
	}

	public void ApplyRotationCamera(float rotationY)
	{
		Vector3 newRotation = new Vector3(_cameraController.Rotation.X, -rotationY,  _cameraController.Rotation.Z );
		_cameraController.Rotation = newRotation;
	}
}
