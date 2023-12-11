using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Space]
    #region variables

    [Header("Player Statistics")]
    [Space(5f)]

    [Range(1f, 8f)]
    [Tooltip("Chicken speed when not found")]
    [SerializeField] private float walkSpeed;
    [Range(3f, 10f)]
    [Tooltip("Chicken speed when found")]
    [SerializeField] private float runSpeed;

    [SerializeField] public bool isDiscovered;
    [SerializeField] public bool isHoldingBaby;


    [Space]

    [Header("Don't touch this !")]
    [Space(5f)]
    [Tooltip("Add the Canvas joystickController script")]
    [SerializeField] private JoystickController joystickController;

    private Rigidbody rb;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float movespeed;

        if(!isDiscovered)
        {
            movespeed = walkSpeed;
        }
        else
        {
            movespeed = runSpeed;
        }

        rb.velocity = (movespeed * joystickController.vecJoystick);
        transform.GetComponentInChildren<Animator>().SetFloat("moveSpeed", Vector3.Distance(rb.velocity, Vector3.zero));
        transform.LookAt(rb.velocity + transform.position);
    }
}
