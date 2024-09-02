using Godot;

public partial class Intro : Control
{
	[Export] private Typewriter _typewriter = null;
	[Export] private TransitionScreen _transition = null;

	public override void _Ready()
	{
		_transition.TransitionOnlyNormal();
	}

	private void OnAnimationFinished(string animationName)
	{
		if (animationName == "fade_to_normal")
			_typewriter.StartWrite(); 
	}
}
