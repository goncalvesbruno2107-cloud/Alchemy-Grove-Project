using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform Canvas;
    [SerializeField] ItemHandler ItemPrefab;
    [SerializeField] IconHandler IconPrefab;
    public GameObject[] Slots;

    public void Refresh()
    {
        ClearSlots();
        FillSlots();
    }

    private void ClearSlots()
    {
        foreach(GameObject Slot in Slots)
        {
            for(int i = 0; i < Slot.transform.childCount; i++)
            {
                Destroy(Slot.transform.GetChild(i).gameObject);
            }
        }
    }

    private void FillSlots()
    {
        for(int i = 0; i < Inventory.PlayerItems.Count; i++)
        {
            ItemHandler ItemInstance = Instantiate(ItemPrefab, Slots[i].transform);
            ItemInstance.Initialize(Inventory.PlayerItems[i]);
        }
    }

    public IconHandler IconInstance(Sprite Sprite)
    {
        IconHandler Instance = Instantiate(IconPrefab, Canvas);
        Instance.transform.SetAsLastSibling();
        Instance.Initialize(Sprite);
        return Instance;
    }
}
