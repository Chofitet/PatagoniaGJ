using Godot;

public partial class MainMenu : Control
{
	[Export] private PackedScene _intro = null;
	[Export] private TransitionScreen _transition = null;
	[Export] private AnimationPlayer _animation = null;

	private void OnStartPressed()
	{
		_transition.TransitionOnlyBlack();
		if (_intro == null) return;
		
	}

	private void OnQuitPressed() => GetTree().Quit();

	private void OnAnimationFinished(string animationName)
	{
		//_transition.TransitionOnlyBlack();
		if (animationName == "fade_to_black")
			GetTree().ChangeSceneToPacked(_intro);
	}
}