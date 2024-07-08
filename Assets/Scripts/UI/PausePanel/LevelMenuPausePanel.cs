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
        protected override void Awake()
        {
            base.Awake();
            closeButton.onClick.AddListener(ClosePausePanel);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            GameActions.OnSetLevelMenuButtonsInteractable?.Invoke(false);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameActions.OnSetLevelMenuButtonsInteractable?.Invoke(true);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
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