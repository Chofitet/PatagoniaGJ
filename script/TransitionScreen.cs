using Godot;

public partial class TransitionScreen : CanvasLayer
{
	[Export] private ColorRect _colorRect = null;
	[Export] private AnimationPlayer _animationPlayer = null;

	Signal _onTransitionFinished;

	public override void _Ready()
	{
		_colorRect.Visible = false;
	}

	public void Transition()
	{
		_colorRect.Visible = true;
		_animationPlayer.Play("fade_to_black");
	}

	private void OnAnimationPlayerAnimationFinished(string animationName)
	{
		if (animationName == "fade_to_black")
		{
			//_onTransitionFinished
			_animationPlayer.Play("fade_to_normal");
		}
		else
			animationName = "fade_to_normal";
				_colorRect.Visible = false;
	}
}
