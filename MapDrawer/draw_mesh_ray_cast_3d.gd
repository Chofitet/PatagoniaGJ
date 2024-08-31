extends RayCast3D
signal NewColliderPoint

func _process(delta: float) -> void:
	pass
	if(is_colliding()):
		var collision_point = get_collision_point()
		
		var collider = get_collider()

		var collision_normal = get_collision_normal()

		
		var auxVector = Vector2(collision_point.x,collision_point.z)
		NewColliderPoint.emit(auxVector)
