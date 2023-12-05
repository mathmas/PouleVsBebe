using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private GameObject joystickController;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject IngameMenu;

    public void DesactiveJoystickController()
    {
        joystickController.SetActive(false);
    }

    public void DesactiveMenuButton()
    {
        menuButton.SetActive(false);
    }

    public void DesactiveIngameMenu()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
