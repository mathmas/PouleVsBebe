using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    #region variables

    [SerializeField] private Transform target;

    [Range(0f, 1f)]
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offSet;

    #endregion

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
