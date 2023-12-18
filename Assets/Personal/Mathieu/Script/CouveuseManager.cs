using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouveuseManager : MonoBehaviour
{
    private List<string> babyTimerList = new();

    private int babyListCount;

    private void Start()
    {
        CheckFirstTime();
    }

    private void Update()
    {
        babyListCount = PlayerPrefs.GetInt("babyCollected") - PlayerPrefs.GetInt("BabyLeaved");

        SetBabyTimerList();
    }

    private void SetBabyTimerList()
    {
        babyTimerList.Clear();
        for(int i = 0; i < babyListCount; i++)
        {
            string itemKeyName = "baby" + (PlayerPrefs.GetInt("babyLeaved") + i + 1).ToString();

            babyTimerList.Add(PlayerPrefs.GetString(itemKeyName));
        }
    }

    private void AddBaby(int time)
    {
        //PlayerPrefs
        PlayerPrefs.GetInt("babyCollected");
    }

    private void CheckFirstTime()
    {
        if (PlayerPrefs.HasKey("babyCollected"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("babyCollected", 0);
            PlayerPrefs.SetInt("BabyLeaved", 0);
        }
    }
}
