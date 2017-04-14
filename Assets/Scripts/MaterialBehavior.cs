using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialBehavior : MonoBehaviour
{
    public int itemID;

    public void Interact()
    {
        print("Interact");
        PlayerBehaviorManager.Instance.DraggingItemID = itemID;
    }
    
}