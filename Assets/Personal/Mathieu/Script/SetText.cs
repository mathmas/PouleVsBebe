using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    [SerializeField] private StoreData storeData;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = storeData.score.ToString();
    }
}
