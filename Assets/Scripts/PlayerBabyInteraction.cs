using System.Collections;
using System.Collections.Generic;
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
        baby.transform.position = transform.position + new Vector3(0f, 0.5f, 0.5f);
        baby.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
        baby.transform.SetParent(transform, true);

    }
}
