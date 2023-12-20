using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUptade : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        GetComponent<RectTransform>().localPosition -= (new Vector3(0,speed,0) * Time.deltaTime);
        if(GetComponent<RectTransform>().localPosition.y > 1000)
        {
            GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
