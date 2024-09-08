using Godot;

public partial class Radar : TextureRect
{
	[Export] private AnimationPlayer _animation = null;

    public void Flash() => _animation.Play("flash_vignette_intensity");
}
