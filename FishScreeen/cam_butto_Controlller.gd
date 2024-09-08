extends Node3D
signal TakePhoto

func _process(delta: float) -> void:
	if Input.is_action_just_pressed("ui_take_photo"):
		TakePhoto.emit()
		$cambtnanim.play("TakePhoto")
