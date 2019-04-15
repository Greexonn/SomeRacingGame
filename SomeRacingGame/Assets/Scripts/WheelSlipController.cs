using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSlipController : MonoBehaviour
{
    public float forwardSlip;
    public float forwardSlipBound;

    public GameObject smokePref;

    private WheelCollider _wheel;
    private WheelHit _info;

    void Start()
    {
        _wheel = GetComponent<WheelCollider>();
    }

    void Update()
    {
        if (_wheel.GetGroundHit(out _info))
        {
            forwardSlip = _info.forwardSlip;

            if (Mathf.Abs(forwardSlip) >= forwardSlipBound)
            {
                Instantiate(smokePref, _info.point, Quaternion.LookRotation(_info.normal));
            }
        }
    }
}
