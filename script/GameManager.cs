using Godot;

public partial class GameManager : Node
{
	[Export] private Rudder _rudder = null;
	[Export] private WorldScreen _worldScreen = null;
	[Export] private TransitionScreen _transition = null;

	[Export] private Sprite3D _televisionCam = null;
	[Export] private Sprite3D _televisionCamTwo = null;

	private bool _canPlayGame = false;

	public override void _Ready()
	{
		_televisionCam.Visible = false;
		_televisionCamTwo.Visible = false;

		_transition.TransitionOnlyNormal();
	}

	public override void _Process(double delta)
	{
		PlayGame();
		//GoToMenuMain();
	}

	public override async void _PhysicsProcess(double delta)
	{
		if (_canPlayGame)
		{
			ActiveTelevision();
			await ToSignal(GetTree().CreateTimer(1.5f), "timeout");
			_rudder.CanMoveRudder = true;
			_worldScreen.ApplyAccelerationCamera(delta);
			ApplyRotation();
		}
	}

	private void PlayGame()
	{
		if (Input.IsActionJustPressed("ui_right") || Input.IsActionJustPressed("ui_left"))
			_canPlayGame = true;
	}

	private void ActiveTelevision()
	{
		_televisionCam.Visible = true;
		_televisionCamTwo.Visible = true;
	}

	private void ApplyRotation()
	{
		_worldScreen.ApplyRotationCamera(-_rudder.Rotation.Z);
	}

	/*private void GoToMenuMain()
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			if (_mainMenu == null) return;
			GetTree().ChangeSceneToPacked(_mainMenu);
		}
	}*/

	private void OnAnimationFinished(string animationName)
	{
		if (animationName == "fade_to_normal")
			GD.Print("Arranca el juego");
	}
}
