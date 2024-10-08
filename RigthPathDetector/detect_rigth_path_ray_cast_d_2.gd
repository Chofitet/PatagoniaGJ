extends RayCast3D
signal OnEndPath
signal OnLimit
var LastCollider

func _physics_process(delta: float) -> void:
	
	if(!is_colliding()): return
	
	var collider = get_collider()
	
	if collider.is_in_group("RigthPath"):
		collider.CheckPassed()
		LastCollider = collider
		
	if collider.is_in_group("EndPath"):
		OnEndPath.emit()
		
	if collider.is_in_group("Limit"):
		OnLimit.emit(LastCollider)
	
