using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    /*
     * This script has to be in a canvas
     */
    #region var

    [SerializeField] private RectTransform rtBack;
    [SerializeField] private RectTransform rtJoystick;

    private float radius;

    public Vector3 vecJoystick;

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
        vec = new Vector2(vec.x / rtBack.rect.width, vec.y / rtBack.rect.height) * 2;

        vecJoystick = new Vector3(vec.x,0f, vec.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rtJoystick.localPosition = Vector3.zero;
        vecJoystick = Vector3.zero;
    }
}
