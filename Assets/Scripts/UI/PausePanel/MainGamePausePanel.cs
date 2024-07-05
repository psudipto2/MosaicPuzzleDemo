using Actions;
using Provider.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.UI.PausePanel
{
    /// <summary>
    /// Manages main game pause panel
    /// </summary>
    public class MainGamePausePanel : PausePanelManager
    {
        #region Variables
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button levelMenuButton;
        [SerializeField] private GameObject soundPanel;
        [SerializeField] private GameObject gameWonPanel;

        private bool isGameWinView;
        #endregion

        #region Properties
        public bool IsGameWinView { set { isGameWinView = value; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            gameObject.SetActive(false);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            if (!isGameWinView)
                DisplayDefaultPauseView();
            else
                DisplayGameWinView();
            GameActions.OnSetMainGameButtonsInteractable?.Invoke(false);
            resumeButton.onClick.AddListener(ClosePanel);
            restartButton.onClick.AddListener(OnClickRestartButton);
            levelMenuButton.onClick.AddListener(OnClickLevelMenuButton);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameActions.OnSetMainGameButtonsInteractable?.Invoke(true);
            resumeButton.onClick.RemoveListener(ClosePanel);
            restartButton.onClick.RemoveListener(OnClickRestartButton);
            levelMenuButton.onClick.RemoveListener(OnClickLevelMenuButton);
        }

        #endregion

        #region Methods
        private void OnClickRestartButton()
        {
            ClosePanel();
            GameActions.OnLevelRestart?.Invoke();
        }

        private void OnClickLevelMenuButton()
        {
            ClosePanel();
            GameActions.OnLeaveMainGame?.Invoke();
            ManagerProvider.Instance.ScenesManager.LoadLevelMenu();
        }

        protected override void OnClickMainMenuButton()
        {
            base.OnClickMainMenuButton();
            GameActions.OnLeaveMainGame?.Invoke();
        }

        private void DisplayGameWinView()
        {
            gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            soundPanel.gameObject.SetActive(false);
            gameWonPanel.gameObject.SetActive(true);
            isGameWinView = false;
        }

        private void DisplayDefaultPauseView()
        {
            resumeButton.gameObject.SetActive(true);
            soundPanel.gameObject.SetActive(true);
            gameWonPanel.gameObject.SetActive(false);

        }
        #endregion
    }
}