using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Shop shop = new();

    public List<ChickenScriptableObjects> chickenScriptableObjects = new();

    public int activePreview;

    private void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/ShopData.json"))
        {
            LoadFromJson();
        }
        else
        {
            shop.chickensAlreadyBuy.Add(true);

            for (int i = 0; i < 8; i++)
            {
                shop.chickensAlreadyBuy.Add(false);
            }

        }
    }

    public void SaveToJson()
    {
        string shopData = JsonUtility.ToJson(shop);
        string filePath = Application.persistentDataPath + "/ShopData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, shopData);
        Debug.Log("ShopData Saved!");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/ShopData.json";
        string shopData = System.IO.File.ReadAllText(filePath);

        shop = JsonUtility.FromJson<Shop>(shopData);
        Debug.Log("Load done!");
    }

    public void SetActiveChicken(int i)
    {
        activePreview = i;
    }
}

[System.Serializable]
public class Shop
{
    public ChickenScriptableObjects activeChicken;

    public List<bool> chickensAlreadyBuy;
}
