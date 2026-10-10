extends Control
class_name ItemHandler

@onready var _texture_rect: TextureRect = $TextureRect

var _item: ItemData = null

@export var _default_color:Color = Color.WHITE
@export var _selected_color:Color = Color.WHITE

func initialize(p_item: ItemData):
	self._item = p_item
	_refresh_ui()
	
func _refresh_ui() -> void:
	_texture_rect.self_modulate = _default_color
	_texture_rect.texture = _item.item_sprite
	
func _create_mouse_icon() -> void:
	var drag_preview: Control = Control.new()
	var preview_img: TextureRect = TextureRect.new()
	
	if preview_img:
		print("TextureRect Found!")
	
	preview_img.texture = _item.item_sprite
	preview_img.expand_mode = TextureRect.EXPAND_IGNORE_SIZE
	preview_img.stretch_mode =TextureRect.STRETCH_KEEP_ASPECT_CENTERED
	
	preview_img.custom_minimum_size = Vector2(32, 32)
	
	preview_img.position = -Vector2(16,16)
	
	drag_preview.add_child(preview_img)
	set_drag_preview(drag_preview)
	
	drag_preview.tree_exited.connect(_on_drag_finished)
	
func _set_selected_color() -> void:
	_texture_rect.self_modulate = _selected_color
	
func _get_drag_data(at_position: Vector2) -> Variant:
	_set_selected_color()
	_create_mouse_icon()
		
	return _item
		

func _on_drag_finished() -> void:
	_texture_rect.self_modulate = _default_color
	_refresh_ui()

	
