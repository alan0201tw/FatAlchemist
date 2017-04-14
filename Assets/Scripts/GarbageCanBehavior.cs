using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCanBehavior : MonoBehaviour
{
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