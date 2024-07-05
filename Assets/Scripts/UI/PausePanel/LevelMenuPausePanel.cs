using Actions;
using Provider.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.UI.PausePanel
{
    /// <summary>
    /// Manages level menu pause panel
    /// </summary>
    public class LevelMenuPausePanel : PausePanelManager
    {
        #region Variables
        [SerializeField] private Button closeButton;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.UIManager.CurrentPausePanel = this;
            gameObject.SetActive(false);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            GameActions.OnSetLevelMenuButtonsInteractable?.Invoke(false);
            closeButton.onClick.AddListener(ClosePausePanel);
            ManagerProvider.Instance.UIManager.CurrentPausePanel = this;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameActions.OnSetLevelMenuButtonsInteractable?.Invoke(true);
            closeButton.onClick.RemoveListener(ClosePausePanel);
        }
        #endregion

        #region Methods
        private void ClosePausePanel()
        {
            ClosePanel();
        }
        #endregion
    }
}