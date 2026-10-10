extends Node

var player_items: Array[ItemData] = []
var _current_ui: InventoryUI = null

var current_ui: InventoryUI:
	get:
		return _current_ui
#	set(value):
#		push_error("Current UI setter is private")
		

func add_to_inventory(p_item: ItemData) -> void:
	player_items.append(p_item)
	
	if current_ui == null:
		return
	refresh_current_ui()
	
func remove_from_inventory(p_item: ItemData) -> void:
	
	player_items.erase(p_item)
	
	refresh_current_ui()
	
func set_current_ui(p_ui: InventoryUI) -> void:
	
	_current_ui = p_ui
	
func refresh_current_ui() -> void:
	
	if _current_ui == null:
		return
		
	current_ui.refresh()
