using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMaterialBehavior : MonoBehaviour
{
    public int itemID;

    public void ClickToDrag()
    {
        PlayerBehaviorManager.Instance.DraggingItemID = itemID;
        PlayerBehaviorManager.Instance.DraggingGameObject = gameObject;
        gameObject.transform.SetAsLastSibling();
    }

    public void OnMouseOver()
    {
        PlayerBehaviorManager.Instance.MouseOverGameObject = gameObject;
    }

    public void OnMouseExit()
    {
        if (PlayerBehaviorManager.Instance.MouseOverGameObject == gameObject)
            PlayerBehaviorManager.Instance.MouseOverGameObject = null;
    }

}