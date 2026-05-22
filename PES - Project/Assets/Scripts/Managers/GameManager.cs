using System;
using Com.IsartDigital.PES.Enum;
using Com.IsartDigital.PES.Manager;
using Com.IsartDigital.PES.Other;
using UnityEngine;
using UnityEngine.Events;

// Author : Florian MAJCHER - Isart DIGITAL
// DATE : 00/00/0000 - Beginning of the class

namespace Com.IsartDigital.PES.Managers
{
    
    public class GameManager : MonoBehaviour
    {
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // VARIABLES
        [SerializeField] private MenuManager _MenuManager;
        
        public static GameManager Instance {get; private set;}

        public Action onGameStart;
        public Action onGamePaused;

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
        
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // READY
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _MenuManager.ShowMenu(EMenuType.PAUSE);
                SetInputsAndCursor(onGamePaused, CursorLockMode.None);
            }
        }

        public void SetInputsAndCursor(Action pAction, CursorLockMode pLockMode)
        {
            pAction?.Invoke();
            Cursor.lockState = pLockMode;
        }
    }
}