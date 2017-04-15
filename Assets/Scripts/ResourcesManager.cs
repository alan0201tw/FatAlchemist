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

        MaterialNameDictionary.Add(1, "Fire");
        MaterialNameDictionary.Add(2, "Water");
        MaterialNameDictionary.Add(3, "Wind");
        MaterialNameDictionary.Add(4, "Stone");
        MaterialNameDictionary.Add(5, "Dirt");
        MaterialNameDictionary.Add(6, "Plant");
        MaterialNameDictionary.Add(7, "Tree");
        MaterialNameDictionary.Add(8, "Gasoline");
        MaterialNameDictionary.Add(9, "Energy");
        MaterialNameDictionary.Add(10, "Life");
        MaterialNameDictionary.Add(11, "Human");
        MaterialNameDictionary.Add(12, "Steam");
        MaterialNameDictionary.Add(13, "Coal");
        MaterialNameDictionary.Add(14, "Wood");
        MaterialNameDictionary.Add(15, "Tool");
        MaterialNameDictionary.Add(16, "Intelligence");
        MaterialNameDictionary.Add(17, "Machine");

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