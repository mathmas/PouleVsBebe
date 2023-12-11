using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBabyInteraction : MonoBehaviour
{
    [SerializeField] public List<GameObject> babysList = new List<GameObject>();

    public void BabyTouch(GameObject baby)
    {
        babysList.Add(baby);
        transform.GetComponentInChildren<Animator>().SetBool("isHoldingBaby", true);
        transform.GetComponentInChildren<Animator>().SetBool("isDiscovered", true);
        GetComponent<PlayerMovement>().isDiscovered = true;

        //To be changed
        baby.transform.SetParent(transform, true);
        baby.transform.position = transform.position + new Vector3(0f, 0.2f, 0f);
        baby.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
        baby.transform.localRotation = new quaternion(0, 0,0,0);

    }
}
