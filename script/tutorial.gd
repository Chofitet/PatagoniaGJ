extends Control

@export var scene : PackedScene

func _ready():
	Input.mouse_mode = Input.MOUSE_MODE_HIDDEN

func ChangeScene(anim):
	get_tree().change_scene_to_packed(scene)
