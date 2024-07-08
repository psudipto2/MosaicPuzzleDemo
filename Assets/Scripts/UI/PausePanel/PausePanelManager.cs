using Actions;
using Provider.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.UI.PausePanel
{
    /// <summary>
    /// Base of all the pause panel in the game
    /// </summary>
    public class PausePanelManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] protected GameObject backgroundFader;
        [SerializeField] protected Button mainMenuButton;
        [SerializeField] protected Button musicButton;
        [SerializeField] protected TMP_Text musicStatusText;
        [SerializeField] protected Button soundButton;
        [SerializeField] private TMP_Text soundStatusText;
        [SerializeField] protected Button exitButton;
        [SerializeField] private AudioClip sfxClip;
        #endregion

        #region Unity Methods
        protected virtual void Awake()
        {
            mainMenuButton.onClick.AddListener(OnClickMainMenuButton);
            musicButton.onClick.AddListener(OnClickMusicutton);
            soundButton.onClick.AddListener(OnClickSoundButton);
            exitButton.onClick.AddListener(OnClickExitButton);    
            gameObject.SetActive(false);
        }
        protected virtual void OnEnable()
        {
            backgroundFader.SetActive(true);
            Time.timeScale = 0;
            SetSoundMusicStatusText(musicStatusText, ManagerProvider.Instance.SoundManager.IsMusicOn);
            SetSoundMusicStatusText(soundStatusText, ManagerProvider.Instance.SoundManager.IsSfxOn);
        }

        protected virtual void OnDisable()
        {
            backgroundFader.SetActive(false);
            Time.timeScale = 1;
        }
        protected virtual void OnDestroy()
        {
            mainMenuButton.onClick?.RemoveListener(OnClickMainMenuButton);
            musicButton?.onClick?.RemoveListener(OnClickMusicutton);
            soundButton?.onClick?.RemoveListener(OnClickSoundButton);
            exitButton?.onClick?.RemoveListener(OnClickExitButton);         
        }
        #endregion

        #region Methods
        protected virtual void OnClickMainMenuButton()
        {
            ClosePanel();
            ManagerProvider.Instance.ScenesManager.LoadMainMenu();
        }

        protected void ClosePanel()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            gameObject.SetActive(false);
        }

        private void OnClickExitButton()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            GameActions.OnExitGame?.Invoke();
        }

        private void OnClickMusicutton()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            bool currentStatus = ManagerProvider.Instance.SoundManager.IsMusicOn;
            GameActions.OnMusicStatusChange?.Invoke(!currentStatus);
            SetSoundMusicStatusText(musicStatusText,!currentStatus);
        }

        private void OnClickSoundButton()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            bool currentStatus = ManagerProvider.Instance.SoundManager.IsSfxOn;
            GameActions.OnSfxStatusChange?.Invoke(!currentStatus);
            SetSoundMusicStatusText(soundStatusText, !currentStatus);
        }

        private void SetSoundMusicStatusText(TMP_Text text, bool value)
        {
            if (value)
                text.text = "ON";
            else
                text.text = "OFF";
        }
        #endregion
    }
}