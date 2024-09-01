using Godot;
using Godot.Collections;

public partial class WorldScreen : Node3D
{
	[Export] private Node3D _cameraController = null;
	[Export] private float _accelerate = 0.8f;
	[Export] private Array<Sprite3D> _fishArray = new Array<Sprite3D>();

	public override void _Ready()
	{
		RandomFish();
	}

	private void RandomFish()
	{
		GD.Randomize();

		Sprite3D fish = _fishArray.PickRandom();
		GD.Print($"Fish: {fish.Name}");
	}

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
	
	public void TransportToLastCheckCollider(Node3D collider)
	{
		GD.Print(collider.GlobalPosition);
		GD.Print(collider.Position);
		Vector3 PosToTranslate = new Vector3(collider.GlobalPosition.X , _cameraController.GlobalPosition.Y ,collider.GlobalPosition.Z);
		_cameraController.Position = PosToTranslate;
	}
}
