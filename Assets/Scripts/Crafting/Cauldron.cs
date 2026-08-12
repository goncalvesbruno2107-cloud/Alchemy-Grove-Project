using System.Collections.Generic;
using UnityEngine;

public class Cauldron : CraftingStation
{
    public override int MaxSize => 4;

    public override bool Craft()
    {
        bool crafting_succeeded;

        string cauldron_key = Recipe.GenerateKey(Ingredients);

        if(ItemDataBase.RecipeDictionary.TryGetValue(cauldron_key, out Item Result))
        {
            Inventory.AddToInventory(Result);
            crafting_succeeded = true;
        }
        else
        {
            crafting_succeeded = false;
        }

        Ingredients.Clear();

        return crafting_succeeded;
    }

    public override void OnDropItem(Item Item)
    {
        Ingredients.Add(Item.id);
    }
}
