
using Godot;

public partial class MainMenu : Control
{
	[Export] private PackedScene _mainGame = null;

	private void OnStartPressed()
	{
		if (_mainGame != null)
		{
			//TransitionScreen.Transition();
			GetTree().ChangeSceneToPacked(_mainGame);
		}
	}

	private void OnOptionsPressed()
	{
		
	}

	private void OnQuitPressed() => GetTree().Quit();
}
