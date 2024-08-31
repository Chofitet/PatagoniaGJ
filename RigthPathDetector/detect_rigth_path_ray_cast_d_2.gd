extends RayCast3D
signal OnEndPath

func _physics_process(delta: float) -> void:
	
	if(!is_colliding()): return
	
	var collider = get_collider()
	
	if collider.is_in_group("RigthPath"):
		collider.CheckPassed()
		
	
	if collider.is_in_group("EndPath"):
		OnEndPath.emit()
	
