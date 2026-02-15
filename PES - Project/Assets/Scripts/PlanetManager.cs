using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author : Florian MAJCHER - Isart DIGITAL
// DATE : 00/00/0000 - Beginning of the class

namespace Com.IsartDigital.PES.Planet
{
    
    public class PlanetManager : MonoBehaviour
    {
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // VARIABLES
        [Range(0, .5f), SerializeField] private float _RotationSpeed;
        [SerializeField] private float _Radius = 5f;
        [SerializeField] private Transform _Center;

        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // PROCESS
        private void Update()
        {
            CircleMovement();
        }

        private void CircleMovement()
        {
            float lAngle = _RotationSpeed * Time.time;
            float lX = Mathf.Cos(lAngle) * _Radius;
            float lZ = Mathf.Sin(lAngle) * _Radius;

            transform.position = new Vector3(lX, transform.position.y, lZ);
        }
    }
}