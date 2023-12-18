using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CouveuseManager : MonoBehaviour
{
    [SerializeField] public List<string> babyTimerList = new List<string>();

    private int babyListCount;

    [SerializeField] private int timerBabyCollect;

    [SerializeField] private Transform nidParent;

    [SerializeField] private Sprite babySprite;
    [SerializeField] private Sprite emptySprite;

    private void Start()
    {
        CheckFirstTime();

        AddBaby(timerBabyCollect);
        AddBaby(timerBabyCollect);
        AddBaby(timerBabyCollect);

        babyListCount = PlayerPrefs.GetInt("babyCollected") - PlayerPrefs.GetInt("babyLeaved");

        Debug.Log("There is " + babyListCount + " baby to collect");


        SetBabyTimerList();

    }

    private void Update()
    {
        babyListCount = PlayerPrefs.GetInt("babyCollected") - PlayerPrefs.GetInt("babyLeaved");

        ShowBabysTimer();
    }

    private void SetBabyTimerList()
    {
        babyTimerList.Clear();

        for(int i = 0; i < babyListCount; i++)
        {
            string itemKeyName = "baby" + (PlayerPrefs.GetInt("babyLeaved") + i + 1).ToString();

            Debug.Log(itemKeyName);

            babyTimerList.Add(PlayerPrefs.GetString(itemKeyName));
        }
    }

    public void AddBaby(int time)
    {
        string babyTimer = ((DateTime.Now.Ticks / 10000000) + time).ToString();

        int babyCollectedValue = PlayerPrefs.GetInt("babyCollected") + 1;
        PlayerPrefs.SetInt("babyCollected", babyCollectedValue);

        Debug.Log("The var babyCollected has " + PlayerPrefs.GetInt("babyCollected") + " value");

        string babyKeyName = "baby" + PlayerPrefs.GetInt("babyCollected");
        PlayerPrefs.SetString(babyKeyName, babyTimer);    
    }

    private void ShowBabysTimer()
    {
        for (int i = 0; i < babyTimerList.Count; i++)
        {
            long babyTimeLeft = (long.Parse(babyTimerList[i])) - (DateTime.Now.Ticks / 10000000);

            long minutesLeft = babyTimeLeft / 60;
            long secondsLeft = babyTimeLeft % 60;

            Text timerText = nidParent.GetChild(i).GetComponentInChildren<Text>();

            timerText.text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");

            nidParent.Find("button").GetComponent<Image>().sprite = emptySprite;

            //Debug.Log("The baby " + i + " will be collectable in " + babyTimeLeft);
        }

        for (int i = babyTimerList.Count; i < nidParent.childCount; i++)
        {
            Text timerText = nidParent.GetChild(i).GetComponentInChildren<Text>();

            nidParent.Find("button").GetComponent<Image>().sprite = babySprite;

            timerText.text = "";
        }
    }

    public void CollectBaby()
    {
        if ((long.Parse(babyTimerList[0])) - (DateTime.Now.Ticks / 10000000) < 1)
        {
            int babyLeaved = PlayerPrefs.GetInt("babyLeaved") + 1;

            PlayerPrefs.SetInt("babyLeaved", babyLeaved);

            string keyName = "baby" + babyLeaved;

            //(PlayerPrefs.GetString(keyName))
            babyTimerList.Remove(PlayerPrefs.GetString(keyName));

            Debug.Log(PlayerPrefs.HasKey(keyName));

            PlayerPrefs.DeleteKey(keyName);

            Debug.Log("Baby collected");

            //PlayerPrefs.SetInt("babyLeaved", babyLeaved + 1);
        }
    }

    private void CheckFirstTime()
    {
        PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("babyCollected"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("babyCollected", 0);
            PlayerPrefs.SetInt("babyLeaved", 0);
        }
    }
}
