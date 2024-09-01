extends Control

@onready var animOlas = $AnimatorOlas
@onready var pivotOlas = $PivotOlas

func RigthWaves():
	pivotOlas.scale = Vector2(1,1)
	animOlas.play("olasGrandes")

func  LeftWaves():
	pivotOlas.scale = Vector2(-1,1)
	animOlas.play("olasGrandes")
