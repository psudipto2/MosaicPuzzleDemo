using Provider.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.UI.MainMenu
{
    /// <summary>
    /// Manages UI related to MainMenu
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            playButton.onClick.AddListener(OnClickPlayButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }
        private void OnDisable()
        {
            playButton.onClick.RemoveListener(OnClickPlayButton);
            exitButton.onClick.RemoveListener(OnClickExitButton);
        }
        #endregion

        #region Methods
        private void OnClickPlayButton()
        {
            ManagerProvider.Instance.ScenesManager.LoadLevelMenu();
        }

        private void OnClickExitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        #endregion
    }
}