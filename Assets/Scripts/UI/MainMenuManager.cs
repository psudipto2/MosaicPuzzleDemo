using Actions;
using Provider.Manager;
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
        [SerializeField] private AudioClip sfxClip;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            playButton.onClick.AddListener(OnClickPlayButton);
            exitButton.onClick.AddListener(OnClickExitButton); 
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveListener(OnClickPlayButton);
            exitButton.onClick.RemoveListener(OnClickExitButton);    
        }
        #endregion

        #region Methods
        private void OnClickPlayButton()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            gameObject.SetActive(false);
            ManagerProvider.Instance.ScenesManager.LoadLevelMenu();
        }

        private void OnClickExitButton()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            GameActions.OnExitGame?.Invoke();
        }
        #endregion
    }
}