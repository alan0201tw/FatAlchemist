using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviorManager : MonoBehaviour
{
    public static PlayerBehaviorManager Instance { get; private set; }

    private int draggingItemID;
    public int DraggingItemID
    {
        get { return draggingItemID; }
        set
        {
            draggingItemID = value;
        }
    }

    public GameObject DraggingGameObject;

    public GameObject MouseOverGameObject;

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

    public void GenerateFieldMaterial()
    {
        GameObject newFieldMaterial = Instantiate(FieldMaterial);
        newFieldMaterial.name = ResourcesManager.Instance.MaterialNameDictionary[draggingItemID];
        newFieldMaterial.GetComponent<Image>().sprite = ResourcesManager.Instance.LoadMaterialSprite(draggingItemID);
        newFieldMaterial.GetComponent<FieldMaterialBehavior>().itemID = draggingItemID;

        newFieldMaterial.transform.SetParent(FieldMaterialContent.transform);
        DraggingGameObject = newFieldMaterial;
    }

    private void Update()
    {
        if (DraggingGameObject != null)
        {
            DraggingGameObject.GetComponent<Image>().raycastTarget = false;
            DraggingGameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (Input.GetMouseButtonUp(0))
            {
                if (DraggingGameObject != null && MouseOverGameObject != null)
                {
                    if (MouseOverGameObject.name == "DeleteMaterial")
                    {
                        Destroy(DraggingGameObject);
                        draggingItemID = 0;
                    }
                    else
                    {
                        foreach (var entry in FormulaManager.Instance.FormulaDictionary)
                        {
                            FieldMaterialBehavior tmp = MouseOverGameObject.GetComponent<FieldMaterialBehavior>();
                            if ((entry.Key.Ingredient1ID == tmp.itemID && entry.Key.Ingredient2ID == DraggingItemID) || (entry.Key.Ingredient2ID == tmp.itemID && entry.Key.Ingredient1ID == DraggingItemID))
                            {
                                InventoryManager.Instance.UnlockMaterial(entry.Value);

                                GameObject newFieldMaterial = Instantiate(FieldMaterial);
                                newFieldMaterial.name = ResourcesManager.Instance.MaterialNameDictionary[entry.Value];
                                newFieldMaterial.GetComponent<Image>().sprite = ResourcesManager.Instance.LoadMaterialSprite(entry.Value);
                                newFieldMaterial.GetComponent<FieldMaterialBehavior>().itemID = entry.Value;

                                newFieldMaterial.transform.SetParent(FieldMaterialContent.transform);
                                newFieldMaterial.transform.position = DraggingGameObject.transform.position;
                                break;
                            }
                        }
                    }
                }
                DraggingGameObject.GetComponent<Image>().raycastTarget = true;
                ReleaseDraggingItem();
            }
        }
    }

    private void ReleaseDraggingItem()
    {
        DraggingGameObject = null;
        draggingItemID = 0;
    }
}