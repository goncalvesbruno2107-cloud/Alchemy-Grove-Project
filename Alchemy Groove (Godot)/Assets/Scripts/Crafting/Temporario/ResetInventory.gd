extends Node

@export var crafting_station:CraftingStation 

func _reset_inventory() -> void:
	crafting_station._ingredients.clear()
	
	Inventory.player_items.clear()
	Inventory.refresh_current_ui()
	
	GameManager.add_starter_package()
