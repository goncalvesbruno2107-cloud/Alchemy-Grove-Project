extends Control
class_name InventoryUI

@export_group("PREFABS")
@export var item_prefab: PackedScene
@export var icon_prefab: PackedScene

@export var grid_container: GridContainer

func _ready() -> void:
	Inventory.set_current_ui(self)
	refresh()

func refresh() -> void:
	clear_slots()
	fill_slots()

func clear_slots() -> void:
	for slot in grid_container.get_children():
		if slot.get_child_count() > 0:
			var child = slot.get_child(0)
			slot.remove_child(child)
			child.queue_free()

func fill_slots() -> void:
	var items = Inventory.player_items
	var slots = grid_container.get_children()
	
	var max_loops = min(items.size(), slots.size())
	
	for i in  range(max_loops):
		var item_instance = item_prefab.instantiate()
		
		slots[i].add_child(item_instance)
		
		if item_instance.has_method("initialize"):
			item_instance.initialize(items[i])
			
