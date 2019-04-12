using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeelController : MonoBehaviour
{
    public WheelCollider weel;

    void Update()
    {
        Vector3 _pos;
        Quaternion _rot;
        weel.GetWorldPose(out _pos, out _rot);
        transform.SetPositionAndRotation(_pos, _rot);
    }
}
