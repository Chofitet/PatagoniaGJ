extends Control

@onready var percent = $Panel/Percent
@onready var line = $MapPlayer/PlayerMap/Line2D

func _ready() -> void:
	SetLineMap()

func SetLineMap():
	line.points = PlayerSettings.PackedArrayLineMap
	percent.text = str(PlayerSettings.Percent) + "%"

func BackMenu():
	get_tree().change_scene_to_file("res://scene/main_menu.tscn")
