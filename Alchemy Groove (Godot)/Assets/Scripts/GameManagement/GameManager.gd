extends Node

@export var starter_package: Array[ItemData] = []

func _ready() -> void:
	load_item_database()
	add_starter_package()

func load_item_database() -> void:
	var path = "res://Resources/Items/"
	
	var dir = DirAccess.open(path)
	
	if dir:
		dir.list_dir_begin()
		var file_name = dir.get_next()
		
		while file_name != "":
			if not dir.current_is_dir() and file_name.ends_with(".tres"):
				var full_path = path + file_name
				
				var item = load(full_path) as ItemData
				
				if item:
					item.initialize()
					
					if(item.recipe == null):
						push_error("Could not load item")
					else:
						ItemDataBase.recipe_dictionary[item.recipe.key] = item
				
			file_name = dir.get_next()
		dir.list_dir_end()
	
	else:
		push_error("Couldn't access path: " + path)

func add_starter_package() -> void:
	for item in starter_package:
		Inventory.add_to_inventory(item)
		print(item.name + " added to Inventory")
		pass
