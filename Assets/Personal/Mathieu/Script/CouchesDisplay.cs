using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CouchesDisplay : MonoBehaviour
{
    [SerializeField] private Text text;
    private void Start()
    {
        PlayerPrefs.SetInt("couches", 10);
    }

    private void Update()
    {
        text.text = PlayerPrefs.GetInt("couches").ToString();
    }
}
