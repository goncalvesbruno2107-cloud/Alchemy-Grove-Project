extends Node2D

@export var canvas_groups: Array[CanvasGroup]
@export var  anim_player: AnimationPlayer

func _ready() -> void:
	GameManager.scene_manager.current_scene = self

func _on_play_pressed() -> void:
	if(anim_player.get_animation("TransitionActive") != null):
		print("There is an animation")
	anim_player.play("TransitionActive")


func _on_transition_finished(anim_name: StringName) -> void:
	if anim_name == "TransitionActive":
		GameManager.scene_manager.load_scene(&"Crafting Scene")

func change_canvas_group(canvas_id: int) -> void:
	for i in canvas_groups.size():
		var _is_current: bool = (i == canvas_id)
		canvas_groups[i].visible = _is_current


func _on_quit_pressed() -> void:
	get_tree().quit()
