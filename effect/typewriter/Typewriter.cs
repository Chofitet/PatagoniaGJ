using Godot;

public partial class Typewriter : Node2D
{
	[Export] private PackedScene _mainGame = null;
	[Export] private Timer _typeTimer = null;
	[Export] private Timer _delayTimer = null;
	[Export] private Label _parentLabel = null;
	[Export] private AudioStreamPlayer _audioStreamTypewriter = null;

	[Export] private TransitionScreen _transitionScreen = null;

	private int _textPosition = 0;
	private string _textToType = string.Empty;
	private bool _initialized = true;

	private void PrepareToType()
	{
		if (_parentLabel == null) return;
		_textToType = _parentLabel.Text;
		_parentLabel.Text = string.Empty;
		_parentLabel.Visible = true;
		_initialized = true;
	}

	private void OnTypeTimerTimeout()
	{
		if (_textPosition >= 0 && _textPosition < _textToType.Length)
		{
			_parentLabel.Text += _textToType[_textPosition];
			_typeTimer.Start();
			_textPosition++;
		}
		else if (_textPosition >= _textToType.Length)
		{
			_textPosition = -1;
			_initialized = false;
			_audioStreamTypewriter.Stop();
			
			
			if (_transitionScreen == null) return;
			_transitionScreen.TransitionOnlyBlack();
			GetTree().ChangeSceneToPacked(_mainGame);
		}
	}

	private void OnDelaytimerTimeout()
	{
		_textPosition = 0;
		_typeTimer.Start();
		_audioStreamTypewriter.Play();
	}

	
	public void StartWrite()
	{
		PrepareToType();
		if(_initialized)
			_delayTimer.Start();
		else
			GD.PrintErr("Aborting: The parent node is not a label. Make sure the typewriter scene is a child to a label node.");
	}

	/*private void OnAnimationFinished(string animationName)
	{
		if (animationName == "fade_to_black")
			GetTree().ChangeSceneToPacked(_mainGame);
	}*/
}
