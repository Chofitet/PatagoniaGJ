using Godot;

public partial class PauseMenu : Control
{
	[Export] private AnimationPlayer _animation = null;

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
		GetTree().Paused = false;
		_animation.PlayBackwards("blur");
	}

	private void Pause()
	{
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
	}

		private void OnQuitPressed()
	{
		GetTree().Quit();
	}

}
