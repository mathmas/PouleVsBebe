using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private GameObject joystickController;
    [SerializeField] public GameObject menuButton;
    [SerializeField] private GameObject couveuseMenu;
    [SerializeField] private GameObject shopMenu;

    public void ToggleJoystickController()
    {
        if (joystickController.activeSelf)
        {
            joystickController.SetActive(false);
        }
        else
        {
            joystickController.SetActive(true);
        }
    }

    public void ToggleMenu()
    {
        if(menuButton.activeSelf)
        {
            menuButton.SetActive(false);
        }
        else
        {
            menuButton.SetActive(true);
        }
    }

    public void ToggleCouveuse()
    {
        if (couveuseMenu.activeSelf)
        {
            couveuseMenu.SetActive(false);
        }
        else
        {
            couveuseMenu.SetActive(true);
        }
    }

    public void ToggleShop()
    {
        if (shopMenu.activeSelf)
        {
            shopMenu.SetActive(false);
        }
        else
        {
            shopMenu.SetActive(true);
        }
    }
}
