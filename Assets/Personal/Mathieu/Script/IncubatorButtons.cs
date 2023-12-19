using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubatorButtons : MonoBehaviour
{
    public void TryCollectBaby()
    {
        Debug.Log("try collect baby");
        GetComponentInParent<IncubatorManager>().CollectBaby(transform.parent.GetSiblingIndex());
    }
}
