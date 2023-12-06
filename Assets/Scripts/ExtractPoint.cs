using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtractPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < col.transform.childCount; i++)
            {
                if (col.transform.GetChild(i).CompareTag("Baby"))
                {
                    Debug.Log("The player extracted with a baby");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
