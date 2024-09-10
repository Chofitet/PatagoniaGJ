using System.Diagnostics.Contracts;
using Godot;

public partial class GameManager : Node
{
	[Export] private PauseMenu _pauseMenu = null;
	[Export] private Rudder _rudder = null;
	[Export] private WorldScreen _worldScreen = null;
	[Export] private TransitionScreen _transition = null;

	[Export] private Sprite3D _televisionCam = null;
	[Export] private Sprite3D _televisionCamTwo = null;

	private bool _canPlayGame = false;

	private float _timeOut = 1.5f;
	

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		_televisionCam.Visible = false;
		_televisionCamTwo.Visible = false;

		_transition.TransitionOnlyNormal();
	}

	public override void _Process(double delta)
	{
		if (_pauseMenu.GameIsPause == false)
			PlayGame();
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_pauseMenu.GameIsPause == true) return;
		if (_canPlayGame)
		{
			ActiveTelevision();
			_timeOut -= (float)delta;
			if (_timeOut <= 0.0f)
			{
				_rudder.CanMoveRudder = true;
				_worldScreen.ApplyAccelerationCamera(delta);
				ApplyRotation();
			}
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

	private void OnAnimationFinished(string animationName)
	{
		if (animationName == "fade_to_normal")
			GD.Print("Arranca el juego");
	}
}
