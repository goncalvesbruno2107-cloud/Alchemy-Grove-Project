using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingStationHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CraftingStation crafting_station;

    Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        crafting_station = GetComponent<CraftingStation>();
    }

    public void TryToAddItem(Item Item)
    {
        if(crafting_station.IngredientsCount >= crafting_station.MaxSize)
        {
            Debug.Log("Max Size Reached");
            return;
        }

        Animator.SetBool("Hover", false);
        crafting_station.OnDropItem(Item);
        Inventory.RemoveFromInventory(Item);
    }

    public void TryToCraft()
    {
        if(crafting_station.IngredientsCount < 1)
        {
            Debug.Log("Station Is Empty");
            return;
        }
        
        if(crafting_station.Craft())
        {
            Debug.Log("Crafting Succeded");
        }
        else
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("EXPLODE!");
        Animator.SetTrigger("Explode");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Animator.SetBool("Hover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Animator.SetBool("Hover", false);
    }

    
}
