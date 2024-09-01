using Godot;

public partial class Intro : Control
{
    [Export] private Typewriter _typewriter = null;

    public override void _Ready()
    {
        _typewriter.StartWrite();
    }
}
