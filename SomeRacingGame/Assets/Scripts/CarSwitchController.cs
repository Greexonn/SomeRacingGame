using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitchController : MonoBehaviour
{
    public GameObject[] cars;

    public Transform startTransform;

    private GameObject _currentCar;
    private SimpleCameraController _cameraController;

    private int _currentCarID = 0;

    void Start()
    {
        _currentCar = Instantiate(cars[_currentCarID], startTransform.position, startTransform.rotation);
        _cameraController = Camera.main.gameObject.GetComponent<SimpleCameraController>();
        _cameraController.target = _currentCar.transform;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            SwitchCar(Input.GetAxisRaw("Mouse ScrollWheel"));
        }

        //check if car is out of bounds
        if (_currentCar.transform.position.y < -10)
            ResetCar();
    }

    private void ResetCar()
    {
        _currentCar.transform.position = startTransform.position;
        _currentCar.transform.rotation = startTransform.rotation;

        Rigidbody _carRigidbody = _currentCar.GetComponent<Rigidbody>();
        _carRigidbody.velocity = Vector3.zero;
        _carRigidbody.angularVelocity = Vector3.zero;
    }

    private void SwitchCar(float dir)
    {
        //change car id
        if (dir <= 0)
        {
            _currentCarID--;
            LoopID();
        }
        else
        {
            _currentCarID++;
            LoopID();
        }

        //switch car
        //store transform
        Vector3 _placementPosition = _currentCar.transform.position + (Vector3.up * 2);
        Quaternion _placementRotation = _currentCar.transform.rotation;

        //destroy current car
        Destroy(_currentCar);

        //place new car
        _currentCar = Instantiate(cars[_currentCarID], _placementPosition, _placementRotation);
        //set new camera target
        _cameraController.target = _currentCar.transform;
    }

    private void LoopID()
    {
        if (_currentCarID == cars.Length)
            _currentCarID = 0;
        else if (_currentCarID < 0)
            _currentCarID = cars.Length - 1;
    }
}
