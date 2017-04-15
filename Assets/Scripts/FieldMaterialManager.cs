using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldMaterialManager : MonoBehaviour
{
    public static FieldMaterialManager Instance { get; private set; }

    [SerializeField]
    private GameObject FieldMaterialContent;
    [SerializeField]
    private GameObject FieldMaterial;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(Instance);
    }

    public GameObject GenerateFieldMaterial(int itemID)
    {
        GameObject newFieldMaterial = Instantiate(FieldMaterial);
        newFieldMaterial.name = ResourcesManager.Instance.MaterialNameDictionary[itemID];
        newFieldMaterial.GetComponent<Image>().sprite = ResourcesManager.Instance.LoadMaterialSprite(itemID);
        newFieldMaterial.GetComponent<FieldMaterialBehavior>().itemID = itemID;
        newFieldMaterial.transform.Find("Name").GetComponent<Text>().text = newFieldMaterial.name;
        newFieldMaterial.transform.SetParent(FieldMaterialContent.transform);

        return newFieldMaterial;
    }

}