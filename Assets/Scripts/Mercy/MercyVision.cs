using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercyVision : MonoBehaviour
{
    [HideInInspector] private MercyBehaviour mercyBehaviour;

    void Start()
    {
        mercyBehaviour = transform.parent.GetComponent<MercyBehaviour>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(mercyBehaviour.angryWithoutBaby)
            {
                BecomeAngry(col.transform);
            }
            else
            {
                for (int i = 0; i < col.transform.childCount; i++)
                {
                    if (col.transform.GetChild(i).CompareTag("Baby"))
                    {
                        BecomeAngry(col.transform);
                    }
                }
            }
        }
    }

    private void BecomeAngry(Transform player)
    {
        if (!mercyBehaviour.isAngry)
        {
            mercyBehaviour.isAngry = true;
            mercyBehaviour.isStunded = true;

            player.GetComponentInChildren<Animator>().SetBool("isDiscovered", true);
            player.GetComponent<PlayerMovement>().isDiscovered = true;
        }
    }
}
