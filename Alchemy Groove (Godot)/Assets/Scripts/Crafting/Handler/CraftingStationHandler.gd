extends Control
class_name CraftingStationHandler

@onready var _crafting_station:CraftingStation = $CraftingStation
@export var _animation_tree:AnimationTree

var _sprite_state_machine: AnimationNodeStateMachinePlayback = null
var _scale_state_machine: AnimationNodeStateMachinePlayback = null

func _ready() -> void:
	if _animation_tree:
		_sprite_state_machine = _animation_tree["parameters/SpriteAnimations/playback"]
		_scale_state_machine = _animation_tree["parameters/ScaleAnimations/playback"]
	
	mouse_entered.connect(_on_mouse_entered)
	mouse_exited.connect(_on_mouse_exited)	

func _can_drop_data(at_position: Vector2, data: Variant) -> bool:
	return data is ItemData and _crafting_station.ingredients_count < _crafting_station.get_max_size()
	
func _drop_data(at_position: Vector2, data: Variant) -> void:
	var _dropped_item = data as ItemData
	_add_item(_dropped_item)
	
func _add_item(p_item: ItemData) -> void:
	SoundManager.play_audio("DropItem")
	_scale_state_machine.travel("OnExit")
	_crafting_station.on_drop_item(p_item)
	Inventory.remove_from_inventory(p_item)
	
func try_to_craft() -> void:
	
	if _crafting_station.craft():
		print("crafting succeeded")
	else:
		_explode()
		

func _explode() -> void:
	print("EXPLODE!")
	SoundManager.play_audio("Explosion")
	if _sprite_state_machine:
		_sprite_state_machine.travel("Explode")
		
func _on_mouse_entered() -> void:
	print("mouse entered")
	_scale_state_machine.get_current_node()
	_scale_state_machine.travel("OnHover")
	SoundManager.play_audio("OnStationHover")
	
func _on_mouse_exited() -> void:
	print("mouse exited")
	_scale_state_machine.travel("OnExit")
	
func try_baking() -> void:
	if _crafting_station.ingredients_count < 1:
		return
	
	SoundManager.play_audio("Baking")
	_sprite_state_machine.travel("Baking")
