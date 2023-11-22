using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variables

    public JoystickController joystickController;

    [SerializeField] private float speed;

    private Rigidbody rb;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = (speed * joystickController.vecJoystick); 
    }
}
