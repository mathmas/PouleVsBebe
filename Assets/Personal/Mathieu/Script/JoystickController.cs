using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    #region var

    [SerializeField] private RectTransform rtBack;
    [SerializeField] private RectTransform rtJoystick;

    public Transform player;
    private float radius;
    [SerializeField] private float playerSpeed;

    private Vector3 VecMove;
    bool touch = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        radius = rtBack.rect.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(touch)
        {
            player.position = VecMove;
        }
    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2 (vecTouch.x - rtBack.position.x, vecTouch.y - rtBack.position.y);

        // 
        vec = Vector2.ClampMagnitude(vec, radius);
        rtJoystick.localPosition = vec;

        float fSqr = (rtBack.position - rtJoystick.position).sqrMagnitude / radius * radius;

        Vector2 vecNormal = vec.normalized;

        VecMove = new Vector3(vecNormal.x * playerSpeed * Time.deltaTime * fSqr, 0f, vecNormal.y * playerSpeed * Time.deltaTime * fSqr);
        player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x,vecNormal.y) * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        touch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        touch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rtJoystick.localPosition = Vector3.zero;
        touch = false;
    }

}
