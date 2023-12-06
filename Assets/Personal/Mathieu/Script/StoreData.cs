using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour
{
    [SerializeField] public int score;
    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("score", score);
        //PlayerPrefs.Save();
    }

    public void AddScore()
    {
        score++;
    }
}
