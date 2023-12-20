using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundInterval : MonoBehaviour
{
    [SerializeField] private float timeInterval;
    [SerializeField] private float currentTime;

    private void Start()
    {
        currentTime = timeInterval;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            GetComponent<AudioSource>().Play();
            currentTime = timeInterval;
        }
    }
}
