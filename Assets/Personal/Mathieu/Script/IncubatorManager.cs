using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncubatorManager : MonoBehaviour
{

    [SerializeField] private int time;

    [SerializeField] private Sprite empty;
    [SerializeField] private Sprite waiting;
    [SerializeField] private Sprite collect;

    public Incubator incubator = new Incubator();


    private void Start()
    {
        LoadFromJson();
    }

    private void Update()
    {
        for(int i = 0; i < incubator.babyIncubators.Count; i++)
        {
            Text childText = transform.GetChild(i).GetComponentInChildren<Text>();
            long babyTimeLeft = long.Parse(incubator.babyIncubators[i].babyEndTimer) - (DateTime.Now.Ticks / 10000000);

            long minutesLeft = babyTimeLeft / 60;
            long secondsLeft = babyTimeLeft % 60;

            if(babyTimeLeft > 0)
            {
                childText.text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");
                SetSprite(waiting, i);
            }
            else
            {
                childText.text = "Ready to collect";
                SetSprite(collect, i);
            }
        }

        for(int i = incubator.babyIncubators.Count; i < transform.childCount; i++)
        {
            Text childText = transform.GetChild(i).GetComponentInChildren<Text>();

            childText.text = "";

            SetSprite(empty, i);
        }
    }

    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(incubator);
        string filePath = Application.persistentDataPath + "/IncubatorData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("IncubatorData Saved!");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/IncubatorData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        incubator = JsonUtility.FromJson<Incubator>(inventoryData);
        Debug.Log("Load done!");
    }

    public void AddIncubatorBaby()
    {
        BabyIncubator newBaby = new BabyIncubator();

        newBaby.babyEndTimer = ((DateTime.Now.Ticks / 10000000) + time).ToString();

        incubator.babyIncubators.Add(newBaby);
    }

    public void CollectBaby(int i)
    {
        if(i < incubator.babyIncubators.Count)
        {
            BabyIncubator baby = incubator.babyIncubators[i];
            string timeBaby = baby.babyEndTimer;

            Debug.Log((long.Parse(timeBaby) - (DateTime.Now.Ticks / 10000000)));

            if ((long.Parse(timeBaby) - (DateTime.Now.Ticks / 10000000)) < 1)
            {
                //Add couche

                incubator.babyIncubators.Remove(baby);
            }
        }
    }

    private void SetSprite(Sprite sprite, int i)
    {
        Transform nid = transform.GetChild(i);
        for (int j = 0; j < nid.childCount; j++)
        {
            if (nid.GetChild(j).CompareTag("Button"))
            {
                Debug.Log(nid.GetChild(j).name);
                nid.GetChild(j).GetComponent<Image>().sprite = sprite;
            }
        }
    }

}


[System.Serializable]
public class Incubator
{
    public List<BabyIncubator> babyIncubators = new List<BabyIncubator>();
}

[System.Serializable]
public class BabyIncubator
{
    public string babyEndTimer;

    public Sprite babySprite;
}
