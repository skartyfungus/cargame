using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;
    private float currentBreakForce;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider FLCol;
    [SerializeField] private WheelCollider FRCol;
    [SerializeField] private WheelCollider RLCol;
    [SerializeField] private WheelCollider RRCol;

    [SerializeField] private Transform FLTrans;
    [SerializeField] private Transform FRTrans;
    [SerializeField] private Transform RLTrans;
    [SerializeField] private Transform RRTrans;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FLCol, FLTrans); ;
        UpdateSingleWheel(FRCol, FRTrans);
        UpdateSingleWheel(RLCol, RLTrans);
        UpdateSingleWheel(RRCol, RRTrans);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = new Quaternion(rot.x, rot.y, rot.z, rot.w);
        wheelTransform.position = pos;
    }

    private void HandleSteering()
    {
        steerAngle = maxSteerAngle * horizontalInput;
        FRCol.steerAngle = steerAngle;
        FLCol.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        FLCol.motorTorque = verticalInput * motorForce;
        FRCol.motorTorque = verticalInput * motorForce;

        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        FLCol.brakeTorque = currentBreakForce;
        FRCol.brakeTorque = currentBreakForce;
        RLCol.brakeTorque = currentBreakForce;
        RRCol.brakeTorque = currentBreakForce;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
}
