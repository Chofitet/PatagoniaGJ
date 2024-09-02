extends Control

@export var scene : PackedScene

func ChangeScene(anim):
	get_tree().change_scene_to_packed(scene)
