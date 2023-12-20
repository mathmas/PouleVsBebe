using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    #region variables

    [SerializeField] public bool isGameStarted;

    [Tooltip("GameObject Camera will follow")]
    [SerializeField] public Transform target;

    [Range(0f, 1f)]
    [SerializeField] private float smoothSpeed;

    [Space(5f)]
    [Tooltip("Distance between the camera and the target when the player is in the main menu")]
    [SerializeField] private Vector3 startOffSet;

    [Space(5f)]
    [Tooltip("Distance between the camera and the target when the player is playing")]
    [SerializeField] private Vector3 playingOffSet;

    #endregion

    private bool trigger;

    private Vector3 offSet;


    [SerializeField] private GameObject backgroundBlack;
    private void Start()
    {
        isGameStarted = false;
    }
    private void FixedUpdate()
    {
        if(!isGameStarted)
        {
            offSet = startOffSet;
        }else
        {
            offSet = playingOffSet;
        }

        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void Update()
    {
        if(target.GetComponent<PlayerMovement>().gameOver && !trigger) 
        {
            GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("Default"));
            trigger = true;

            target.transform.rotation = new Quaternion(0,0,0,0);
            target.transform.Rotate(Vector3.up * 140);
            smoothSpeed = 1;
            backgroundBlack.SetActive(true);

            playingOffSet = startOffSet ;
            transform.LookAt(target.position);
            target.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
