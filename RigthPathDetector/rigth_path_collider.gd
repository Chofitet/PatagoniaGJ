extends Area3D

var checked : bool = false
@onready var cube = $CollisionShape3D2

func CheckPassed():
	cube.visible = false;
	checked = true

func get_was_collide() -> bool:
	return checked
