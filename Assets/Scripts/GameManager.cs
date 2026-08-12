using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public Item[] StarterPackage; 
    [SerializeField] InventoryUI InitialUI;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        LoadItemDataBase();
    }

    void Start()
    {
        AddStarterPackage();
        Inventory.SetCurrentUI(InitialUI);
        Inventory.RefreshCurrentUI();
    }
    
    public void LoadItemDataBase()
    {
        List<Item> items = Resources.LoadAll<Item>("Items").ToList();
        
        foreach(Item item in items)
        {
            item.Initialize();

            if(item.Recipe == null)
            {
                Debug.Log($"Could not load item: {item.Name}");
                continue;
            }

            ItemDataBase.RecipeDictionary[item.Recipe.Key] = item;
        }
    }

    public void AddStarterPackage()
    {
        foreach(Item Item in StarterPackage)
        {
            Inventory.AddToInventory(Item);
        }
    }
}
