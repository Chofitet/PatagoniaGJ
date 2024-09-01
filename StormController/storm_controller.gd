extends Node3D

signal OnSetStorm
var LastDirection = 1
@onready var controlWindow = $SpriteWindow/SubViewport/ControlWindow

func _ready() -> void:
	$Timer.wait_time = randf_range(20,30)
	$Timer.timeout.connect(SetStorm)
	
func SetStorm():
	var direction
	
	if LastDirection == 1:
		controlWindow.LeftWaves()
		direction = -1
	else: 
		controlWindow.RigthWaves()
		direction = 1
	
	LastDirection = direction
	
