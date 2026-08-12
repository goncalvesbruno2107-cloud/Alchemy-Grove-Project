using System.Collections.Generic;
using UnityEngine;

public abstract class CraftingStation : MonoBehaviour
{
    public abstract int MaxSize { get; }

    protected List<int> Ingredients = new();
    public int IngredientsCount => Ingredients.Count;

    public abstract void OnDropItem(Item Item);
    public abstract bool Craft();
}
