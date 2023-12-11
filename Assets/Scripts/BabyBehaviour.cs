using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //Set all mercy Angry
            GameObject parent = transform.parent.gameObject;
            for(int i = 0; i < parent.transform.childCount; i++)
            {
                if(parent.transform.GetChild(i).CompareTag("Mercy"))
                {
                    Debug.Log(parent.transform.GetChild(i).name);
                    parent.transform.GetChild(i).GetComponent<MercyBehaviour>().isAngry = true;
                }
            }

            PlayerBabyInteraction playerBabyInteraction = col.gameObject.GetComponentInParent<PlayerBabyInteraction>();
            playerBabyInteraction.BabyTouch(this.gameObject);
            GetComponentInChildren<Animator>().SetTrigger("Grabbed");
        }
    }
}
