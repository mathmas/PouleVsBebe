using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    /*
     * How this script works ?
     * 
     *  This script only works if a eventSystem is in the scene
     *  This script has to be in a canvas
     * 
     *  In a canva
     * 
     *      - First it needs a joystick (image) and a background for the joystick (image)
     *      - And an image transparent on the top of it
     *  
     * When you touch the screen, the joystick (global) appear under your touch
     * 
     */
    #region var

    [Tooltip("Put the rect transform component of the background of the joystick")]
    [SerializeField] private RectTransform rtBack;
    [Tooltip("Put the rect transform component of the joystick")]
    [SerializeField] private RectTransform rtJoystick;

    [Tooltip("Put the background GameObject")]
    [SerializeField] private GameObject backJoystick;

    private float radius;

    [HideInInspector] public Vector3 vecJoystick;

    #endregion

    void Start()
    {
        radius = rtBack.rect.width / 2;
    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2 (vecTouch.x - rtBack.position.x, vecTouch.y - rtBack.position.y);

        //Clamp the joystick inside of the joystick background
        vec = Vector2.ClampMagnitude(vec, radius);
        rtJoystick.localPosition = vec;

        //Normalize vec
        vec = new Vector2(vec.x / radius, vec.y / radius);

        vecJoystick = new Vector3(vec.x,0f, vec.y);

        transform.GetComponentInParent<MenuFunctions>().menuButton.SetActive(false);
        Camera.main.GetComponent<CamBehaviour>().isGameStarted = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // OnTouch(eventData.position);
        backJoystick.SetActive(true);
        rtBack.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rtJoystick.localPosition = Vector3.zero;
        vecJoystick = Vector3.zero;
        backJoystick.SetActive(false);
    }
}
