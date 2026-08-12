using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image Image;
    private Item Item;

    [SerializeField] Color DefaultColor;
    [SerializeField] Color SelectedColor;
    
    private IconHandler IconInstance;

    public void Initialize(Item Item)
    {
        Image = GetComponent<Image>();
        this.Item = Item;
        RefreshUI();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CreateMouseIcon();
        SetSelectedColor();
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetIconPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RefreshUI();
        DestroyIcon();
        CheckCraftingStation(eventData.pointerCurrentRaycast.gameObject);
    }

    private void RefreshUI()
    {
        Image.color = DefaultColor;
        Image.sprite = Item.ItemSprite;
    }

    private void CreateMouseIcon()
    {
        IconInstance = Inventory.CurrentUI.IconInstance(Item.ItemSprite);
        IconInstance.Initialize(Item.ItemSprite);
    }

    private void SetSelectedColor()
    {
        Image.color = SelectedColor;
    }

    private void SetIconPosition()
    {
        IconInstance.transform.position = Mouse.current.position.ReadValue();
    }

    private void DestroyIcon()
    {
        Destroy(IconInstance.gameObject);
        IconInstance = null;
    }

    private void CheckCraftingStation(GameObject CheckedObject)
    {
        if(!CheckedObject) 
        { 
            return; 
        }
        
        if(!CheckedObject.TryGetComponent(out CraftingStationHandler stationHandler))
        {
            Debug.Log("Crafting Station Not Found");
            return;
        }

        stationHandler.TryToAddItem(Item);
    }
}
