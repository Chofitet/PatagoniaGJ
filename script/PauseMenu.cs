using Godot;

public partial class PauseMenu : Control
{
	[Export] private AnimationPlayer _animation = null;

	private bool _gameIsPause = false;

	public bool GameIsPause { get { return _gameIsPause; } }

	public override void _Ready()
	{
		_animation.Play("RESET");
	}

	public override void _Process(double delta)
	{
		TestPause();
	}

	private void Resume()
	{
		_gameIsPause = false;
		GetTree().Paused = false;
		Input.MouseMode = Input.MouseModeEnum.Captured;
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		_animation.PlayBackwards("blur");
	}

	private void Pause()
	{
		_gameIsPause = true;
		Input.MouseMode = Input.MouseModeEnum.Captured;
		Input.MouseMode = Input.MouseModeEnum.Visible;
		GetTree().Paused = true;
		_animation.Play("blur");
	}

	private void TestPause()
	{
		if (Input.IsActionJustPressed("ui_cancel") && !GetTree().Paused)
			Pause();
		else if (Input.IsActionJustPressed("ui_cancel") && GetTree().Paused)
			Resume();
	}

	private void OnResumePressed()
	{
		Resume();
	}

		private void OnRestartPressed()
	{
		Resume();
		GetTree().ReloadCurrentScene();
		//_animation.PlayBackwards("blur");
	}

		private void OnQuitPressed()
	{
		GetTree().Quit();
	}

}
