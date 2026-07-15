using UnityEngine;

[System.Serializable] // para ver no Inspector da Unity
public class InventorySlot
{
    public ItemData item;
    public int amount;

    // Construtor para quando adicionamos um item em um slot vazio
    public InventorySlot(ItemData sourceItem, int sourceAmount)
    {
        item = sourceItem;
        amount = sourceAmount;
    }

    public InventorySlot()
    {
        item = null;
        amount = 0;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public bool IsEmpty()
    {
        return item == null;
    }
}