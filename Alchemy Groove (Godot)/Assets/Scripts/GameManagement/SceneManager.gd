extends Node
class_name SceneManager

@onready var _game: Node2D = self.get_parent()
var current_scene: Node2D = null

func _ready() -> void:
	GameManager.set_scene_manager(self)

var _scene_catalogue: Dictionary[StringName, String] = {
	&"Menu": "res://Assets/Scenes/menu.tscn",
	&"Crafting Scene": "res://Assets/Scenes/crafting_scene.tscn"
}

func set_current_scene(scene: Node2D) -> void:
	current_scene = scene

func load_scene(scene: StringName) -> void:
	var new_scene: PackedScene = load(_scene_catalogue[scene])
	print(_scene_catalogue[scene])
	var loaded_scene: Node2D = new_scene.instantiate()
	
	if loaded_scene != null:
		print("Scene Loaded Succesfully")
	
	if current_scene != null:
		current_scene.queue_free()
	
	_game.add_child(loaded_scene)
	set_current_scene(loaded_scene)
