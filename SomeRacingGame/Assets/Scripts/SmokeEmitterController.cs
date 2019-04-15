using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEmitterController : MonoBehaviour
{
    private Vector3 _offset;

    private Quaternion _rotation;

    void Start()
    {
        _offset = transform.position - transform.parent.position;
        _rotation = transform.rotation;
    }

    void Update()
    {
        transform.position = transform.parent.position + _offset;
        transform.rotation = _rotation;
    }
}
