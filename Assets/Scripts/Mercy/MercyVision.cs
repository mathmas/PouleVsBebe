using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercyVision : MonoBehaviour
{
    public MercyBehaviour mercyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        mercyBehaviour = transform.parent.GetComponent<MercyBehaviour>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < col.transform.childCount; i++)
            {
                if (col.transform.GetChild(i).CompareTag("Baby"))
                {
                    if(!mercyBehaviour.isAngry)
                    {
                        mercyBehaviour.isAngry = true;
                        mercyBehaviour.isStunded = true;
                    }
                }
            }
        }
    }
}
