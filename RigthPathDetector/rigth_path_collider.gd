extends Area3D

var checked : bool = false

func CheckPassed():
	checked = true

func get_was_collide() -> bool:
	return checked
