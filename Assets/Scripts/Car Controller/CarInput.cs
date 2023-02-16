using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class CarInput : MonoBehaviour
{
    [SerializeField] private RaceManager _raceManager;
    private CarController _carController;
    private void Awake()
    {
        _carController = GetComponent<CarController>();
    }

    void Update()
    {
        if (_raceManager.IsRaceActive())
        {
            _carController.SetThrottle(Input.GetAxis("Vertical"));
            _carController.SetSteering(Input.GetAxis("Horizontal"));
        }
    }
}
