using Provider.Manager;
using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager.Scenes
{
    /// <summary>
    /// Manages all game scenes
    /// </summary>
    public class ScenesManager : PersistentSingleton<ScenesManager>
    {
        private int currentSceneIndex;
        #region Unity Methods
        protected override void Awake()
        {
            base.Awake();
            ManagerProvider.Instance.ScenesManager = this;
            currentSceneIndex = 1;
        }
        #endregion

        #region Methods
        public void LoadMainMenu()
        {
            if (currentSceneIndex != 1)
            {
                SceneManager.LoadScene(1);
                currentSceneIndex = 1;
            }
            ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.SetActive(false);
            ManagerProvider.Instance.UIManager.MainMenuManager.gameObject.SetActive(true);
        }

        public void LoadLevelMenu()
        {
            if (currentSceneIndex != 1)
            {
                SceneManager.LoadScene(1);
                currentSceneIndex = 1;
            }
            ManagerProvider.Instance.UIManager.MainMenuManager.gameObject.SetActive(false);
            ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.SetActive(true);
        }

        public void LoadMainGame()
        {
            if (currentSceneIndex != 2)
            {
                SceneManager.LoadScene(2);
                currentSceneIndex = 2;
            }
            ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.SetActive(false);
        }
        #endregion
    }
}