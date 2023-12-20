using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtractPoint : MonoBehaviour
{
    public Incubator incubator = new Incubator();

    [SerializeField] private int time;

    [SerializeField] private bool timerStarted;
    [SerializeField] private float timeWait;
    [SerializeField] private float currentTime;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < col.transform.childCount; i++)
            {
                if (col.transform.GetChild(i).CompareTag("Baby"))
                {
                    if(File.Exists(Application.persistentDataPath + "/IncubatorData.json"))
                    {
                        LoadFromJson();
                        if(incubator.babyIncubators.Count > 0)
                        {
                            time = 3600;
                        }else
                        {
                            time = 300;
                        }
                    }
                    AddIncubatorBaby();

                    SaveToJson();

                    GetComponentInChildren<Animator>().SetTrigger("close");
                    Debug.Log("The player extracted with a baby");

                    List<GameObject> mercyList = GameObject.FindGameObjectsWithTag("Mercy").ToList();

                    for(int j = 0; j < mercyList.Count;j++)
                    {
                        mercyList[j].GetComponent<MercyBehaviour>().agent.speed = 0f;
                        mercyList[j].GetComponent<MercyBehaviour>().runSpeed = 0f;
                        mercyList[j].GetComponent<MercyBehaviour>().walkSpeed = 0f;
                        mercyList[j].GetComponentInChildren<Animator>().SetBool("isAngry", false);
                    }

                    col.gameObject.GetComponent<PlayerMovement>().runSpeed = 0f;
                    col.gameObject.GetComponent<PlayerMovement>().walkSpeed = 0f;

                    col.transform.position = transform.position;
                    timerStarted  = true;
                    currentTime = timeWait;
                }
            }
        }
    }
    private void Update()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if(currentTime < 0)
            {
                if(SceneManager.sceneCountInBuildSettings <= SceneManager.sceneCount)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
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
}
