using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChickenAbilities : MonoBehaviour
{
    public Shop shop;
    private PlayerMovement playerMovement;
    private ChickenScriptableObjects chicken;

    private void Start()
    {
        LoadFromJson();
        playerMovement = GetComponent<PlayerMovement>();
        chicken = shop.activeChicken;

        SetPlayerChicken();

        ChangePlayerAbilities();
    }

    private void SetPlayerChicken()
    {
        GameObject player = this.gameObject;
        GameObject playerBody = Instantiate(chicken.chickenBody, player.transform.position, player.transform.rotation, player.transform.GetChild(0));

        Debug.Log(playerBody);

        Destroy(player.transform.GetChild(0).GetChild(0).gameObject);
    }

    private void ChangePlayerAbilities()
    {
        List<GameObject> mercyList = GameObject.FindGameObjectsWithTag("Mercy").ToList();
        if (chicken.invisible)
        {
            for (int i = 0; i < mercyList.Count; i++)
            {
                mercyList[i].GetComponent<MercyBehaviour>().angryWithoutBaby = false;
            }
        }
        else
        {
            for (int i = 0; i < mercyList.Count; i++)
            {
                mercyList[i].GetComponent<MercyBehaviour>().angryWithoutBaby = true;
            }
        }

        playerMovement.walkSpeed *= chicken.speedMultiplicator;
        playerMovement.runSpeed *= chicken.speedMultiplicator;
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/ShopData.json";
        string shopData = System.IO.File.ReadAllText(filePath);

        shop = JsonUtility.FromJson<Shop>(shopData);
        Debug.Log("Load done!");
    }
}
