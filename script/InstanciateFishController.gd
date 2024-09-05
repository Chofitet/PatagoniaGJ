extends Control

signal FishShow
var FishInstance1 = preload("res://scene/path_fish.tscn")
var FishInstance2 = preload("res://scene/path_fish_2.tscn")
var FishInstance3 = preload("res://scene/path_fish_3.tscn")
var FishPull :=[]

func _ready() -> void:
	FillFishPull()
	
	$Timer.wait_time = randf_range(10,15)
	$Timer.timeout.connect(InstanceFish)
	

func FillFishPull():
	FishPull.append(FishInstance1)
	FishPull.append(FishInstance2)
	FishPull.append(FishInstance3)

func InstanceFish():
	var fish
	if !FishPull.is_empty():
		fish = FishPull[0].instantiate()
		FishShow.emit(FishPull.size())
		FishPull.remove_at(0)
	else:
		FillFishPull()
		fish = FishPull[0].instantiate()
	
	add_child(fish)
