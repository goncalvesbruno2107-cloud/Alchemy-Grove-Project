using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using Unity.Collections;

public class Inventory
{
    public static List<Item> PlayerItems = new();

    public static InventoryUI CurrentUI { get; private set; }
    
    public static void AddToInventory(Item Item)
    {
        PlayerItems.Add(Item);
        if(CurrentUI == null) {return;}
        RefreshCurrentUI();
    }

    public static void RemoveFromInventory(Item Item)
    {
        PlayerItems.Remove(Item);
        if(CurrentUI == null) {return;}
        RefreshCurrentUI();
    }

    public static void SetCurrentUI(InventoryUI UI)
    {
        CurrentUI = UI;
    }

    public static void RefreshCurrentUI()
    {
        CurrentUI.Refresh();
    }
}
