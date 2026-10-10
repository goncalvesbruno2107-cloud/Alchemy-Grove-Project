class_name Recipe

var _ingredients: Array[int]:
	get:
		return _ingredients.duplicate()
		
var key: String:
	get:
		return key
	#set(value):
		#push_error("Key cannot be set by another class")
	
func _init(p_ingredients: Array[int]):
	_ingredients = p_ingredients
	
	key = generate_key(_ingredients)
	
static func generate_key(p_ingredients: Array[int]) -> String:
	var sorted_ingredients = p_ingredients.duplicate()
	sorted_ingredients.sort()
	return "-".join(sorted_ingredients)
