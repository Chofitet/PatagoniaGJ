extends Node3D

var actualFish
@onready var NoRegister = $MapViewPort/FishScreen/NoRegister
@onready var Merluza = $"MapViewPort/FishScreen/Merluza Negra"
@onready var Sardina = $"MapViewPort/FishScreen/Sardina Fueguina"
@onready var Cangrejo = $MapViewPort/FishScreen/Cangrejo
@onready var FishDictionary = [Cangrejo,Sardina,Merluza]
@onready var tutorial = $MapViewPort/FishScreen/CamTutorial
var isAFishInCam = false

#Button Push
func ShowPanelInfo():
	tutorial.visible = false
	NoRegister.visible = false
	for fish in FishDictionary:
		fish.visible = false
		
	if !isAFishInCam:
		NoRegister.visible = true
		await get_tree().create_timer(3).timeout
		tutorial.visible = false
	else:
		FishDictionary[actualFish].visible = true;

#cuando pasa un pez
func SetActualFish(fishNum):
	print("pez")
	actualFish = fishNum
	isAFishInCam = true
	await get_tree().create_timer(3).timeout
	isAFishInCam = false
