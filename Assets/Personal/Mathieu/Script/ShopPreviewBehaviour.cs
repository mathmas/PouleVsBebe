using System.Collections;
using System.Collections.Generic;
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

            shopManager.shop.activeChicken = chickenToPreview.name;
        }
        else
        {
            previewCost.text = chickenToPreview.cost.ToString();
            coucheIcon.SetActive(true);
        }
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
