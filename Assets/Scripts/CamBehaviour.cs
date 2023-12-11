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

    private void Start()
    {
        isGameStarted = false;
    }
    private void FixedUpdate()
    {
        Vector3 offSet;
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


}
