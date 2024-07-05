using UnityEngine;
using Provider.Manager;
using Manager.UI.MainMenu;
using Manager.UI.Level;
using UnityEngine.UI;
using Actions;
using Manager.UI.PausePanel;

namespace Manager.UI
{
    /// <summary>
    /// Manages whole UI related stuffs in the title
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private MainMenuManager mainMenuManager;
        [SerializeField] private LevelUIManager levelUIManager;
        [SerializeField] private Button settingsButton;
        [SerializeField] private PausePanelManager levelMenuPausePanel;
        [SerializeField] private PausePanelManager mainGamePausePanel;
        [SerializeField] private AudioClip sfxClip;

        private PausePanelManager currentPausePanel;
        #endregion

        #region Properties
        public MainMenuManager MainMenuManager { get { return mainMenuManager; } }
        public LevelUIManager LevelUIManager { get { return levelUIManager; } }
        public PausePanelManager CurrentPausePanel { get { return currentPausePanel; } set { currentPausePanel = value; } }
        public Button SettingsButton { get { return settingsButton; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.UIManager = this;
            settingsButton.onClick.AddListener(OnClickSettingsButton);           
            settingsButton.gameObject.SetActive(false);
            levelUIManager.gameObject.SetActive(false);
            levelMenuPausePanel.gameObject.SetActive(false);
            mainGamePausePanel.gameObject.SetActive(false);
            GameActions.OnSetLevelMenuButtonsInteractable += SetSettingsButtonInteractable;
            GameActions.OnSetMainGameButtonsInteractable += SetSettingsButtonInteractable;
        }

        private void OnDestroy()
        {
            settingsButton.onClick.RemoveListener(OnClickSettingsButton);
            GameActions.OnSetLevelMenuButtonsInteractable -= SetSettingsButtonInteractable;
            GameActions.OnSetMainGameButtonsInteractable -= SetSettingsButtonInteractable;
        }
        #endregion

        #region Methods
        private void OnClickSettingsButton()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            //Hack Fix for pause panel not coming up at first time
            if (LevelUIManager.gameObject.activeInHierarchy)
                levelMenuPausePanel.gameObject.SetActive(true);
            else
                mainGamePausePanel.gameObject.SetActive(true);
            if (LevelUIManager.gameObject.activeInHierarchy)
                levelMenuPausePanel.gameObject.SetActive(true);
            else
                mainGamePausePanel.gameObject.SetActive(true);
        }

        private void SetSettingsButtonInteractable(bool val)
        {
            settingsButton.interactable = val;
        }
        #endregion
    }
}
