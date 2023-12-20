using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopPreviewBehaviour : MonoBehaviour
{
    [SerializeField] private ShopManager shopManager;

    public Text previewName;
    public Text previewDescription;
    public Image previewSprite;
    public Text previewCost;
    public GameObject coucheIcon;


    [SerializeField] private ChickenScriptableObjects chickenToPreview;

    [SerializeField] private RuntimeAnimatorController animatorController;

    private void Update()
    {
        chickenToPreview = shopManager.chickenScriptableObjects[shopManager.activePreview];
        previewName.text = chickenToPreview.name;
        previewDescription.text = chickenToPreview.description;
        previewSprite.sprite = chickenToPreview.spritePreview;

        if (shopManager.shop.chickensAlreadyBuy[shopManager.activePreview])
        {
            previewCost.text = "equiped";
            coucheIcon.SetActive(false);

            shopManager.shop.activeChicken = chickenToPreview;
        }
        else
        {
            previewCost.text = chickenToPreview.cost.ToString();
            coucheIcon.SetActive(true);
        }
    }

    public void SetPlayerChicken()
    {
        if (shopManager.shop.chickensAlreadyBuy[shopManager.activePreview])
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            GameObject playerBody = Instantiate(shopManager.chickenScriptableObjects[shopManager.activePreview].chickenBody, player.transform.position, player.transform.rotation, player.transform.GetChild(0));

            Debug.Log(playerBody);

            Destroy(player.transform.GetChild(0).GetChild(0).gameObject);

            //Give this to the player
            //shopManager.chickenScriptableObjects[shopManager.activePreview];
        }
    }

    public void ChangePlayerAbilities()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        List<GameObject> mercyList = GameObject.FindGameObjectsWithTag("Mercy").ToList();

        if (chickenToPreview.invisible)
        {
            for (int i = 0; i < mercyList.Count; i++)
            {
                mercyList[i].GetComponent<MercyBehaviour>().angryWithoutBaby = false;
            }
        }else
        {
            for (int i = 0; i < mercyList.Count; i++)
            {
                mercyList[i].GetComponent<MercyBehaviour>().angryWithoutBaby = true;
            }
        }
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.walkSpeed *= chickenToPreview.speedMultiplicator;
        playerMovement.runSpeed *= chickenToPreview.speedMultiplicator;
    }

    public void TryToBuy()
    {
        if(!shopManager.shop.chickensAlreadyBuy[shopManager.activePreview])
        {
            int money = PlayerPrefs.GetInt("couches");
            if (chickenToPreview.cost <= money)
            {
                PlayerPrefs.SetInt("couches", money -  chickenToPreview.cost);
                shopManager.shop.chickensAlreadyBuy[shopManager.activePreview] = true;
            }
        }
    }
}
