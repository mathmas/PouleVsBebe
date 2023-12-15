using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerWorld : MonoBehaviour
{
    [SerializeField] private long test;

    private void Start()
    {
        test = System.DateTime.Now.Ticks;

        Debug.Log((System.DateTime.Now.Ticks - test) / 10000000 + " seconds past from star");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log((System.DateTime.Now.Ticks - test) / 10000000 + " seconds past from star");
        }
    }
}
