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
            draggingItemID = value; GenerateFieldMaterial();
        }
    }

    private GameObject draggingGameObject;

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
        GameObject newItem = new GameObject("Item" + draggingItemID.ToString());
        newItem.AddComponent<Image>();
        newItem.GetComponent<Image>().sprite = ResourcesManager.Instance.LoadMaterialSprite(draggingItemID);

        newItem.transform.SetParent(FieldMaterial.transform);
        draggingGameObject = newItem;
    }

    private void Update()
    {
        if (draggingGameObject != null)
        {
            draggingGameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if(Input.GetMouseButtonDown(0))
            {
                draggingGameObject = null;
            }
        }
    }

}