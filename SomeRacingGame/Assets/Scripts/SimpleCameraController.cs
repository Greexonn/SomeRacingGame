using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;

    public float smoothness;

    void FixedUpdate()
    {
        Vector3 _desiredPos = target.position + target.TransformDirection(offset);
        Vector3 _smoothPos = Vector3.Lerp(transform.position, _desiredPos, smoothness * Time.deltaTime);
        transform.position = _smoothPos;
        transform.LookAt(target, Vector3.up);
    }
}
