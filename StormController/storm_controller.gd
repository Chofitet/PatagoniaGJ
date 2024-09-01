extends Node3D

signal OnSetStorm
signal StopStorm
var LastDirection = 1
@onready var controlWindow = $SpriteWindow/SubViewport/ControlWindow
@onready var BoatMoveAnim = $BoatBounceMoveAnim
@export var Objects : Node3D

func _ready() -> void:
	$Timer.wait_time = randf_range(10,15)
	$Timer.timeout.connect(SetStorm)
	
func SetStorm():
	var direction
	
	if LastDirection == 1:
		controlWindow.LeftWaves()
		direction = -1
		AnimOlaCrash("LeftMoveAnim")
	else: 
		controlWindow.RigthWaves()
		direction = 1
		AnimOlaCrash("RigthMoveAnim")
	
	OnSetStorm.emit(LastDirection)
	await get_tree().create_timer(1).timeout
	StopStorm.emit()
	LastDirection = direction


func AnimOlaCrash(animName):
	var aux = BoatMoveAnim.get_animation(animName)
	aux.track_set_key_value(1,0,Objects.rotation)
	BoatMoveAnim.play(animName)
	await  BoatMoveAnim.animation_finished
	BoatMoveAnim.play("idle_anim")
