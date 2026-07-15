using UnityEngine;

[CreateAssetMenu(fileName = "NovoItem", menuName = "Alchemy Grove/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int maxStackSize = 16; // Limite máximo do stack
    // adicionar depois outros dados tipo de ingrediente, valor, etc...
}