using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

// Author : Florian MAJCHER - Isart DIGITAL
// DATE : 00/00/0000 - Beginning of the class

namespace Com.IsartDigital.PES.Player
{
    
    public class Player : MonoBehaviour
    {
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // VARIABLES
        [SerializeField] private float _Speed = 10f;
        [SerializeField] private float _SmoothTime = 15f;
        [SerializeField] private float _RotationSensitivity = .2f;

        private Vector3 _CurrentVelocity;
        private Vector3 _TargetVelocity;
        
        private float _RotationX = 0f;
        private float _RotationY = 0f;

        private const float MAX_VALUE_ROTATION = 89f;
        
        private CustomInputs _Inputs;
        
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // READY
        private void Awake()
        {
            _Inputs = new CustomInputs();
            _Inputs.Enable();
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // PROCESS
        private void Update()
        {
            Movements();
            MouseRotation();
        }
        
        private void Movements()
        {
            Vector2 lInput = _Inputs.PlayerInputs.Move.ReadValue<Vector2>();
            Vector2 lUpAndDown = _Inputs.PlayerInputs.UpAndDown.ReadValue<Vector2>();
            Vector3 lTargetInput = new Vector3(lInput.x, lUpAndDown.y, lInput.y);
            
            _CurrentVelocity = Vector3.Lerp(_CurrentVelocity, lTargetInput, _SmoothTime * Time.deltaTime);
            transform.position += _CurrentVelocity * _Speed * Time.deltaTime;
        }

        private void MouseRotation()
        {
            Vector2 lMouseDelta = Mouse.current.delta.ReadValue();

            _RotationY += lMouseDelta.x * _RotationSensitivity;
            _RotationX -= lMouseDelta.y * _RotationSensitivity;
            _RotationX = Mathf.Clamp(_RotationX, -MAX_VALUE_ROTATION, MAX_VALUE_ROTATION);

            Quaternion lTargetRotation = Quaternion.Euler(_RotationX, _RotationY, 0f);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, lTargetRotation, _SmoothTime * Time.deltaTime);
        }
    }
}