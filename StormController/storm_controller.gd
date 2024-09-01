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
	
	OnSetStorm.emit(direction)
	get_tree().create_timer(0.5).timeout
	OnSetStorm.emit(direction)
	
	LastDirection = direction
	
