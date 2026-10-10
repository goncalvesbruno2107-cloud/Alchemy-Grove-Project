extends CraftingStation
class_name Cauldron

func get_max_size() -> int:
	return 4
	
func on_drop_item(p_item: ItemData) -> void:
	_ingredients.append(p_item.id)
	
func craft() -> bool:
	var _crafting_succeeded: bool = false
	var _cauldron_key: String = Recipe.generate_key(_ingredients)
	
	if ItemDataBase.recipe_dictionary.has(_cauldron_key):
		var result_item: ItemData = ItemDataBase.recipe_dictionary[_cauldron_key]
		Inventory.add_to_inventory(result_item)
		_crafting_succeeded = true
	else:
		_crafting_succeeded = false
	
	_ingredients.clear()
	return _crafting_succeeded
