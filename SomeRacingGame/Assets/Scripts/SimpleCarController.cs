using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float enginePower;
    public float brakePower;
    public float steerAngle;
    public float steerSpeed;
    public Vector3 centerOfMassOffset;

    public WheelCollider[] controlWeels;
    public WheelCollider[] torqueWeels;

    void Start()
    {
        Vector3 _center = GetComponent<Rigidbody>().centerOfMass + centerOfMassOffset;
        GetComponent<Rigidbody>().centerOfMass = _center;
    }

    void Update()
    {
        //control torque
        foreach (var wheel in torqueWeels)
        {
            wheel.motorTorque = enginePower * Input.GetAxis("Vertical");
        }

        //steering control
        foreach (var wheel in controlWeels)
        {
            wheel.steerAngle = Mathf.Lerp(wheel.steerAngle, (steerAngle * Input.GetAxis("Horizontal")), Time.deltaTime * steerSpeed);
        }

        //brake control
        foreach (var wheel in torqueWeels)
        {
            wheel.brakeTorque = Input.GetAxis("Jump") * brakePower * 1.5f;
        }
        foreach (var wheel in controlWeels)
        {
            wheel.brakeTorque = Input.GetAxis("Jump") * brakePower;
        }        
    }
}
