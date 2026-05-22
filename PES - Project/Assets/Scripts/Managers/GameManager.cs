using System;
using Com.IsartDigital.PES.Other;
using UnityEngine;

// Author : Florian MAJCHER - Isart DIGITAL
// DATE : 00/00/0000 - Beginning of the class

namespace Com.IsartDigital.PES.Managers
{
    
    public class GameManager : MonoBehaviour
    {
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // VARIABLES
        public static GameManager Instance {get; private set;}

        public Action onGameStart;

        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // READY
        private void Awake()
        {
            #region SINGLETON
            if (Instance != this && Instance != null)
            {
                Destroy(this);
                Debug.LogError(nameof(Instance) + Utils.ERR_INSTANCE);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);
            #endregion
        }

        private void OnEnable()
        {
            
        }
        
        private void OnDisable()
        {
        
        }
        
        public void ActivateInputs() => onGameStart?.Invoke();
    }
}