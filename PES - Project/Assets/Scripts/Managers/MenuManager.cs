using System;
using DG.Tweening;
using System.Collections.Generic;
using Com.IsartDigital.PES.Enum;
using Com.IsartDigital.PES.Managers;
using Com.IsartDigital.PES.UI;
using UnityEngine;
using UnityEngine.UI;

// Author : Florian MAJCHER - Isart DIGITAL
// DATE : 00/00/0000 - Beginning of the class

namespace Com.IsartDigital.PES.Manager
{

    public class MenuManager : MonoBehaviour
    {
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // VARIABLES
        [SerializeField] private AudioClip _MenuMusic;
        [SerializeField] private AudioClip _GameMusic;
        
        private const float TWEEN_SCALE = 1f;
        private const float TWEEN_DURATION = .5f;

        private readonly Dictionary<EMenuType, GameObject> _Menus = new Dictionary<EMenuType, GameObject>();
        
        private bool _IsGamePlaying;

        private GameManager _GameManager => GameManager.Instance;
        
        // ----------------~~~~~~~~~~~~~~~~~~~==========================# // READY
        private void Awake()
        {
            RegisterMenus();
            RegisterButtons();

            ShowMenu(EMenuType.MAIN);
        }

        private void RegisterMenus()
        {
            _Menus.Clear();
            
            foreach (MenuType lMenu in FindObjectsByType<MenuType>(FindObjectsInactive.Include, FindObjectsSortMode.None))
                _Menus[lMenu.type] = lMenu.gameObject;
        }

        private void RegisterButtons()
        {
            MenuButton[] lButtons = FindObjectsByType<MenuButton>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (MenuButton lButton in lButtons)
            {
                Button lUIButton = lButton.GetComponent<Button>();
                EMenuType lTarget = lButton.TargetMenu;

                lUIButton.onClick.AddListener(() => ShowMenu(lTarget));
            }
        }

        public void ShowMenu(EMenuType pType)
        {
            CheckType(pType);
            
            Transform lActiveMenu = _Menus[pType].transform;

            foreach (GameObject lMenu in _Menus.Values)
                if (lMenu != null) lMenu.SetActive(false);
            
            lActiveMenu.gameObject.SetActive(true);
            lActiveMenu.localScale = Vector3.zero;
            lActiveMenu.DOScale(TWEEN_SCALE, TWEEN_DURATION).SetEase(Ease.OutBack);
        }

        private void CheckType(EMenuType pType)
        {
            switch (pType)
            {
                case EMenuType.MAIN:
                    break;
                case EMenuType.PLAY:
                    _GameManager.ActivateInputs();
                    break;
                case EMenuType.OPTIONS:
                    break;
                case EMenuType.CREDITS:
                    break;
                case EMenuType.TITLE_CARD:
                    break;
                case EMenuType.PAUSE:
                    break;
                case EMenuType.QUIT:
 #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                    break;
#else
                Application.Quit();
                    break;
#endif
                    break;
            }
        }
    }
}