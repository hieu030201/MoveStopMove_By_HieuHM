using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    public Transform playerTF;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1f)]
    public float SmoothFactor = 0.5f;

    private void Start()
    {
        _cameraOffset = transform.position - playerTF.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = playerTF.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}
