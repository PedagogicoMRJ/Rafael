using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Car Settings")]
    public float accelerationFactor = 30f;
    public float turnFactor = 3.5f;
    public float driftFactor = 1f;
    public float maxSpeed = 30;
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float velocityUp = 0;
    Rigidbody2D carRig;
    private void Awake()
    {
        carRig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        ApplyForce();
        DriftContol();
        ApplySteering();
    }
    void ApplyForce()
    {
        velocityUp = Vector2.Dot(transform.up, carRig.velocity);
        if (velocityUp > maxSpeed && accelerationInput > 0)
        return;
        if (velocityUp < -maxSpeed && accelerationInput < 0)
        return;
        if (carRig.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        return;
        if (accelerationInput == 0)
        carRig.drag = Mathf.Lerp(carRig.drag, 3f,Time.fixedDeltaTime * 3);
        else carRig.drag = 0;
        Vector2 forceVector = transform.up * accelerationInput * accelerationFactor;
        carRig.AddForce(forceVector, ForceMode2D.Force); 
    }
    void ApplySteering()
    {
        float minSpeedTurn = (carRig.velocity.magnitude/8);
        minSpeedTurn = Mathf.Clamp01(minSpeedTurn);
        rotationAngle-= steeringInput*turnFactor*minSpeedTurn;
        carRig.MoveRotation(rotationAngle);
    }
    void DriftContol()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRig.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRig.velocity, transform.right);
        carRig.velocity = forwardVelocity + rightVelocity * driftFactor;
    }
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
