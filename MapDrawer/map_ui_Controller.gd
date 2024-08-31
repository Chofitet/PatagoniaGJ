extends Control

@export var LineReposition : float = 10
@onready var Line2d = $Line2D
@onready var BoatIcon = $Line2D/BoatIcon
@onready var lastPoint = Vector2(0,0)
 
func RefreshLine(vector2):
	
	#Dede el game managr le debe llegar el vector 2 dede 
	
	var vectorPosition = vector2 * LineReposition
	
	Line2d.add_point(vectorPosition)
	
	BoatIcon.position = vectorPosition
	
	var direction = lastPoint - vectorPosition
	var angle = direction.angle()
	
	if(direction != Vector2.ZERO):
		BoatIcon.rotation = angle
	
	
	if(rad_to_deg(angle) > 0):
		BoatIcon.flip_v= true
	else: BoatIcon.flip_v = false
	
	lastPoint = vectorPosition
