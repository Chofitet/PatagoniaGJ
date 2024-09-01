extends Node3D

@onready var ColliderConteiner = $ColliderConteiner
var AllColliders =[]
var NumOfAllColliders
var Actual
signal OnEndPath

func  _ready() -> void:
	AllColliders = ColliderConteiner.get_children()
	NumOfAllColliders = AllColliders.size()

func EndPath():
	OnEndPath.emit()
	PlayerSettings.Percent = CalculatePercent()
	get_tree().change_scene_to_file("res://scene/ResultScreen.tscn")
	


func CalculatePercent() -> float:
	var countnum = 0
	
	for collider in AllColliders:
		if(collider.get_was_collide()):
			countnum += 1
	
	if countnum == 0: return 0
	
	var percent = (countnum * 100) / NumOfAllColliders
	
	return percent
