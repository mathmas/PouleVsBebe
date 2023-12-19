using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsScripts : MonoBehaviour
{
    public void activePreview()
    {
        Debug.Log(transform.parent.GetSiblingIndex());
        Debug.Log(GetComponentInParent<Transform>().GetComponentInParent<ShopManager>().name);
        GetComponentInParent<Transform>().GetComponentInParent<ShopManager>().SetActiveChicken(transform.GetSiblingIndex()); 
    }

}
