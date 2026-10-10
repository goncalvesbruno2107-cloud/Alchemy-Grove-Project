extends Node
class_name CraftingStation

var max_size: int:
	get:
		return get_max_size()
		
var _ingredients:Array[int] = []

var ingredients_count: int:
	get:
		return _ingredients.size()
		
func get_max_size() -> int:
	push_error("Abstract function not implemented yet")
	return 0
		
func on_drop_item(p_item: ItemData) -> void:
	push_error("Abstract function not implemented yet")
	
func craft() -> bool:
	push_error("Abstract function not implemented yet")
	return false
