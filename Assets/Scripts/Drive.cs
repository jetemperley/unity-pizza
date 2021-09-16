using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public Rigidbody rb;
    
    bool grounded = true;

    public void Start(){
        foreach (AxleInfo axleInfo in axleInfos) {
            axleInfo.leftWheel.ConfigureVehicleSubsteps(0.1f, 1, 8);
            axleInfo.rightWheel.ConfigureVehicleSubsteps(0.1f, 1, 8);
        }
        rb.centerOfMass = rb.centerOfMass + Vector3.down;
        rb.AddForce(Vector3.forward*100);
    }
        
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis(Axis.VERTICAL);
        float steering = maxSteeringAngle * Input.GetAxis(Axis.HORIZONTAL);
        float handbrake = Input.GetButton(Axis.SPACE) ? float.PositiveInfinity : 0;
        grounded = true;

        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            if (axleInfo.handbrake) {
                // Debug.Log($"handbrake {handbrake}");
                axleInfo.leftWheel.brakeTorque = handbrake;
                axleInfo.rightWheel.brakeTorque = handbrake;
            }
            if (!axleInfo.leftWheel.isGrounded || !axleInfo.rightWheel.isGrounded) {
                grounded = false;
            }
        }

        if (grounded) {
            // rb.AddForce(Quaternion.Euler(-90, 0, 0)*rb.velocity*0.2f*Time.deltaTime, ForceMode.VelocityChange);    
        }

    }
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
    public bool handbrake; // use handbrake
}