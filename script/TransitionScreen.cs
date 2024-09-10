using Godot;

public partial class TransitionScreen : CanvasLayer
{
	[Export] private ColorRect _colorRect = null;
	[Export] private AnimationPlayer _animationPlayer = null;

	public override void _Ready()
	{
		_colorRect.Visible = false;
	}

	public void Transition()
	{
		_colorRect.Visible = true;
		_animationPlayer.Play("fade_to_black");
	}

	public void TransitionOnlyBlack()
	{
		_colorRect.Visible = true;
		_animationPlayer.Play("fade_to_black");
	}

	public void TransitionOnlyNormal()
	{
		_colorRect.Visible = true;
		_animationPlayer.Play("fade_to_normal");
	}
}
