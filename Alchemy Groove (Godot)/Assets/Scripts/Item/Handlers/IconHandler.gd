extends Control
class_name IconHandler

@export var _image: TextureRect = null
var _sprite: Texture2D = null

func initialize(p_sprite: Texture2D) -> void:
	_sprite = p_sprite

func _ready() -> void:
	
	if _image:
		print("TextureRect Found!")
		_render_icon()
	
func _render_icon() -> void:
	_image.texture = _sprite
