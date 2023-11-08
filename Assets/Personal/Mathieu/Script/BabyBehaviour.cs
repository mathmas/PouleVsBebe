using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerBabyInteraction playerBabyInteraction = col.gameObject.GetComponentInParent<PlayerBabyInteraction>();
            playerBabyInteraction.BabyTouch(this.gameObject);
        }
            

    }
}
