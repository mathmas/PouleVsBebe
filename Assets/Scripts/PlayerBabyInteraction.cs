using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBabyInteraction : MonoBehaviour
{
    [SerializeField] public List<GameObject> babysList = new List<GameObject>();

    public void BabyTouch(GameObject baby)
    {
        babysList.Add(baby);

        //To be changed
        baby.transform.position = transform.position + new Vector3(0f, babysList.Count + 0.5f, 0f);
        baby.transform.SetParent(transform, true);
    }
}
