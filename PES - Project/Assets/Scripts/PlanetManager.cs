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
        [SerializeField] private int _Steps = 50;
        [SerializeField] private Transform _Center;
        [SerializeField] private LineRenderer _LineRenderer;
        
        private const float TWO_PI = Mathf.PI * 2f;

        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // READY
        private void Start() => DrawOrbit();
        
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // PROCESS
        private void Update()
        {
            CircleMovement();
            
            if (_Center) 
                DrawOrbit();
        }

        private void CircleMovement()
        {
            float lAngle = _RotationSpeed * Time.time;
            float lX = Mathf.Cos(lAngle) * _Radius;
            float lZ = Mathf.Sin(lAngle) * _Radius;

            transform.position = new Vector3(lX, transform.position.y, lZ);
        }

        private void OnDrawGizmos()
        {
            Vector3 lCenterPos = (_Center != null) ? _Center.position : Vector3.zero;

            Gizmos.color = Color.white;
            Gizmos.DrawLine(lCenterPos, transform.position);
            Gizmos.DrawWireSphere(transform.position, .5f);
        }
        
        private void DrawOrbit()
        {
            _LineRenderer.positionCount = _Steps;
            for (int i = 0; i < _Steps; i++)
            {
                float lProgress = (float)i / _Steps;
                float lRadian = lProgress * TWO_PI;

                float lX = Mathf.Cos(lRadian) * _Radius;
                float lZ = Mathf.Sin(lRadian) * _Radius;

                Vector3 lPos = new Vector3(lX, 0, lZ) + _Center.position;
                _LineRenderer.SetPosition(i, lPos);
            }
            _LineRenderer.loop = true;
        }
    }
}