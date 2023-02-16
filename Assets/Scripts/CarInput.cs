using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput : MonoBehaviour
{
    private CarController _carController;
    private void Awake()
    {
        _carController = GetComponent<CarController>();
    }

    void Update()
    {
        _carController.SetThrottle(Input.GetAxis("Vertical"));
        _carController.SetSteering(Input.GetAxis("Horizontal"));
    }
}
