using Actions;
using Data.Level;
using Provider.Manager;
using UnityEngine;

namespace Manager.Scenes
{
    /// <summary>
    /// Manages all game scenes
    /// </summary>
    public class ScenesManager : MonoBehaviour
    {
        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.ScenesManager = this;
            GameActions.OnExitGame += ExitGame;
        }

        private void OnDestroy()
        {
            GameActions.OnExitGame -= ExitGame;
        }
        #endregion

        #region Methods
        public void LoadMainMenu()
        {
            ManagerProvider.Instance.UIManager.MainMenuManager.gameObject.SetActive(true);
            ManagerProvider.Instance.UIManager.SettingsButton.gameObject.SetActive(false);
            if (ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.activeInHierarchy)
                ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.SetActive(false);
            if (ManagerProvider.Instance.MainGameManager.gameObject.activeInHierarchy)
                ManagerProvider.Instance.MainGameManager.gameObject.SetActive(false);
        }

        public void LoadLevelMenu()
        {
            ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.SetActive(true);
            ManagerProvider.Instance.UIManager.SettingsButton.gameObject.SetActive(true);
            if (ManagerProvider.Instance.MainGameManager.gameObject.activeInHierarchy)
                ManagerProvider.Instance.MainGameManager.gameObject.SetActive(false);
            GameActions.OnLoadLevelMenu?.Invoke();
        }

        public void LoadMainGame(LevelData levelData)
        {
            ManagerProvider.Instance.UIManager.LevelUIManager.gameObject.SetActive(false);
            ManagerProvider.Instance.MainGameManager.gameObject.SetActive(true);
            GameActions.OnLevelStart(levelData);
        }

        public void ExitGame()
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