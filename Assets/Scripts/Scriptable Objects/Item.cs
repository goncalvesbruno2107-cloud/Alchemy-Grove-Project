using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public int id; // 0 for empty slot. Do not use
    public int[] ingredients;
    public string Name;

    public Sprite ItemSprite;

    public Recipe Recipe{ get; private set; }

    public void Initialize()
    {
        Recipe = new(ingredients);
    }
}
