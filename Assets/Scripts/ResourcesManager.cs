using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance { get; private set; }

    public Dictionary<int, string> MaterialNameDictionary = new Dictionary<int, string>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(Instance);

        MaterialNameDictionary.Add(1, "Apple");
        MaterialNameDictionary.Add(2, "Bread");
        MaterialNameDictionary.Add(3, "Coal");
        MaterialNameDictionary.Add(4, "Egg");
        MaterialNameDictionary.Add(5, "Electricity");
        MaterialNameDictionary.Add(6, "Fire");
        MaterialNameDictionary.Add(7, "Gasoline");
        MaterialNameDictionary.Add(8, "Gold");
        MaterialNameDictionary.Add(9, "Water");
        MaterialNameDictionary.Add(10, "Wood");

        LoadAllSprites();
    }

    private void LoadAllSprites()
    {
        foreach (var entry in MaterialNameDictionary)
        {
            Sprite tmp = Resources.Load("MaterialSprites/" + entry.Value, typeof(Sprite)) as Sprite;
        }
    }

    public Sprite LoadMaterialSprite(int itemID)
    {
        if (MaterialNameDictionary.ContainsKey(itemID))
        {
            return Resources.Load("MaterialSprites/" + MaterialNameDictionary[itemID], typeof(Sprite)) as Sprite;
        }
        else return null;
    }

}