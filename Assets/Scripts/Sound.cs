using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    private void Start()
    {
        GetComponent<AudioSource>().clip = sound;
    }
}
