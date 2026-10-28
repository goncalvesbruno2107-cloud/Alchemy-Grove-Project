extends Control
class_name InteractableHover

@export var expand_factor: float = 0.1

var _original_scale:Vector2

func _ready() -> void:
	_original_scale = scale
	mouse_entered.connect(_on_mouse_entered)
	mouse_exited.connect(_on_mouse_exited)
	emit_sound.connect(SoundManager.play_audio)
	pass

func _on_mouse_entered() -> void:
	scale = _original_scale * (1.0 + expand_factor)
	emit_sound.emit("OnHover")
	
func _on_mouse_exited() -> void:
	scale = _original_scale

signal emit_sound(sound_name: String)
