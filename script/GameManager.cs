using Godot;

public partial class GameManager : Node
{
	[Export] private CharacterBody3D _rudder = null;
	[Export] private WorldScreen _worldScreen = null;
	//[Export] private BoatRotation _boat = null; 

	public override void _PhysicsProcess(double delta)
	{
		_worldScreen.ApplyAccelerationCamera(delta);
		//_boat.ApplyForceMovement();
		ApplyRotation();
	}

	private void ApplyRotation()
	{
		_worldScreen.ApplyRotationCamera(-_rudder.Rotation.Z);
	}
}
