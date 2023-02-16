using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarController : MonoBehaviour
{
    [SerializeField] private float engineForce;
    [SerializeField] private float steeringForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] [Range(0,1)] private float driftFactor;
    [SerializeField] [Range(0, 1)] private float slowNoSteerFactor;
    [SerializeField] [Range(0, 1)] private float backwardsMaxSpeedPercentage;
    
    private Rigidbody2D _rigidbody2D;
    private float _throttle;
    private float _steering;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetThrottle(float throttle)
    {
        _throttle = Mathf.Clamp(throttle,-1,1);
    }

    public void SetSteering(float steering)
    {
        _steering = Mathf.Clamp(steering,-1,1);
    }

    void FixedUpdate()
    {
       ThrottleTick();
       StopHorizontalMovement();
       SteeringTick();
    }

    private void ThrottleTick()
    {
        if (_throttle == 0)
        {
            _rigidbody2D.drag = Mathf.Lerp(_rigidbody2D.drag, 2, Time.deltaTime*5);
        }
        else
        {
            _rigidbody2D.drag = 0;
        }

        float forwardVelocityFactor = Vector2.Dot(transform.up, _rigidbody2D.velocity);
        if (forwardVelocityFactor > maxSpeed && _throttle > 0)
        {
            return;
        }

        if (forwardVelocityFactor < -maxSpeed*backwardsMaxSpeedPercentage && _throttle < 0)
        {
            return;
        }

        //Apply the throttle
        _rigidbody2D.AddForce(transform.up * (_throttle * engineForce));
    }

    private void SteeringTick()
    {
        //limit ability to steer depending on speed
        float minSpeedBeforeTurning = _rigidbody2D.velocity.magnitude * slowNoSteerFactor;
        minSpeedBeforeTurning = Mathf.Clamp01(minSpeedBeforeTurning);
        
        //apply the steering
        float torque = -_steering * steeringForce * minSpeedBeforeTurning;
        _rigidbody2D.AddTorque(torque);
    }
    
    void StopHorizontalMovement()
    {
        //limit horizontal movement
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_rigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_rigidbody2D.velocity, transform.right);
        _rigidbody2D.velocity = forwardVelocity + (rightVelocity * driftFactor);
    }
}
