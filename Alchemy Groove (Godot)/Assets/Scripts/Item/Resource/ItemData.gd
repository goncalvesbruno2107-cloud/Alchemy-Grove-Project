extends Resource
class_name ItemData

@export var id: int = 0; #0 for empty
@export var ingredients: Array[int] = []
@export var name: String = ""

@export var item_sprite: Texture2D

var _recipe: Recipe = null

var recipe: Recipe:
	get:
		return _recipe;
	set(value):
		push_error("recipe setter is private!")

func initialize() -> void:
	_recipe = Recipe.new(ingredients)
