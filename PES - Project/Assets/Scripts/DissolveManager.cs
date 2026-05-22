using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author : Florian MAJCHER - Isart DIGITAL
// DATE : 00/00/0000 - Beginning of the class

namespace Com.IsartDigital.PES.Shaders
{
    
    public class DissolveManager : MonoBehaviour
    {
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // VARIABLES
        private Material _DissolveMaterialShader;
        private float _DissolveValue;
        private const float DISSOLVE_SPEED = 1f;

        private const float DISSOLVE_MIN_VALUE = .5f;
        private const float DISSOLVE_MAX_VALUE = 1.2f;

        private const string DISSOLVE_SHADER_PROPERTY_NAME = "_Dissolve";

        private static readonly int Dissolve = Shader.PropertyToID(DISSOLVE_SHADER_PROPERTY_NAME);
        
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // READY
        private void Awake()
        {
            _DissolveMaterialShader = GetComponent<MeshRenderer>().material;
        }

        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // PROCESS
        private void Update()
        {
            DissolveOnSin();
        }

        private void DissolveOnSin()
        {
            float lSin = Mathf.Sin(Time.time * DISSOLVE_SPEED);
            float lNormalized = (lSin + 1f) * .5f;              
            _DissolveValue = Mathf.Lerp(DISSOLVE_MIN_VALUE, DISSOLVE_MAX_VALUE, lNormalized);

            _DissolveMaterialShader.SetFloat(Dissolve, _DissolveValue);
        }
    }
}