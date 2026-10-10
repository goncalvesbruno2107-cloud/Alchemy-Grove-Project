extends Node

var _sound_catalog:Dictionary[String, Array] = {
		"OnHover": ["res://Assets/Audio/SFX/OnHover.wav", -5.0],
		"OnStationHover": ["res://Assets/Audio/SFX/StationHover.wav", -12.0],
		"DropItem": ["res://Assets/Audio/SFX/DropItem.wav", -3.0],
		"Baking": ["res://Assets/Audio/SFX/Baking.wav", -5.0],
		"Explosion": ["res://Assets/Audio/SFX/Explosion.wav", -12.0]
	}
	
@onready var _audio_player: AudioStreamPlayer = AudioStreamPlayer.new()

func _ready() -> void:
	add_child(_audio_player)
	
func play_audio(p_audio_name: String) -> void:
	if _sound_catalog.has(p_audio_name):
		var audio_path = _sound_catalog[p_audio_name][0]
		var audio_volume = _sound_catalog[p_audio_name][1]
		var stream: AudioStream = load(audio_path)
		
		if stream:
			_audio_player.stream = stream
			_audio_player.volume_db = audio_volume
			_audio_player.play()

	else:
		push_warning("Audio does not exist")
