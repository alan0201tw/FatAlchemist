using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public Dictionary<int, bool> Inventory = new Dictionary<int, bool>(); // store itemID-to-unlocked

    [SerializeField]
    private GameObject InventoryScrollViewContent;
    [SerializeField]
    private GameObject InventoryElement;

    enum UpdateInventoryType
    {
        Add, Remove
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(Instance);
    }

    private void Start()
    {
        //Initialize Inventory by setting all material to locked (false)
        foreach (var entry in ResourcesManager.Instance.MaterialNameDictionary)
        {
            Inventory.Add(entry.Key, false);
        }

        UnlockMaterial(1);
        UnlockMaterial(2);
        UnlockMaterial(3);
        UnlockMaterial(4);
    }

    public void UnlockMaterial(int itemID)
    {
        if (Inventory[itemID] == true) return;

        Inventory.Remove(itemID);
        Inventory.Add(itemID, true);
        UpdateInventoryUI(UpdateInventoryType.Add, itemID);
    }

    private void UpdateInventoryUI(UpdateInventoryType updateType, int itemID)
    {
        if (updateType == UpdateInventoryType.Add)
        {
            GameObject newItem = Instantiate(InventoryElement);
            newItem.name = ResourcesManager.Instance.MaterialNameDictionary[itemID];
            newItem.GetComponent<MaterialBehavior>().itemID = itemID;
            newItem.GetComponent<Image>().sprite = ResourcesManager.Instance.LoadMaterialSprite(itemID);
            newItem.transform.Find("Name").GetComponent<Text>().text = newItem.name;

            newItem.transform.SetParent(InventoryScrollViewContent.transform);
        }
    }

}