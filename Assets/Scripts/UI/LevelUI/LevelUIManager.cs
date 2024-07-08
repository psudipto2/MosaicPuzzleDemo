using Actions;
using Enums;
using Manager.UI.PausePanel;
using Provider.Manager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.UI.Level
{
    /// <summary>
    /// Manages all level ui in the Game
    /// </summary>
    public class LevelUIManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Button easyButton;
        [SerializeField] private Button mediumButton;
        [SerializeField] private Button hardButton;
        [SerializeField] private Button defaultLevelButton;
        [SerializeField] private LevelType defaultLevelType;
        [SerializeField] private PausePanelManager levelMenuPausePanel;
        [SerializeField] private AudioClip sfxClip;

        private List<Button> levelSelectionButtons = new List<Button>();
        private Button currentLevelSelectionButton;
        #endregion

        #region Properties
        public PausePanelManager LevelMenuPausePanelManager {  get { return levelMenuPausePanel; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {        
            easyButton.onClick.AddListener(OnClickEasyButton);
            mediumButton.onClick.AddListener(OnClickMediumButton);
            hardButton.onClick.AddListener(OnClickHardButton);
            levelSelectionButtons.Add(easyButton);
            levelSelectionButtons.Add(mediumButton);
            levelSelectionButtons.Add(hardButton);
            GameActions.OnSetLevelMenuButtonsInteractable += SetAllButtonsInteractable;
        }

        private void OnEnable()
        {
            GameActions.OnChangeCurrentLevelType?.Invoke(defaultLevelType);
            currentLevelSelectionButton = defaultLevelButton;
            OnChangeCurentSelectedButton(currentLevelSelectionButton);
            ManagerProvider.Instance.UIManager.CurrentPausePanel = levelMenuPausePanel;
        }

        private void OnDestroy()
        {
            GameActions.OnSetLevelMenuButtonsInteractable -= SetAllButtonsInteractable;
            easyButton.onClick.RemoveListener(OnClickEasyButton);
            mediumButton.onClick.RemoveListener(OnClickMediumButton);
            hardButton.onClick.RemoveListener(OnClickHardButton);
            levelSelectionButtons.Clear();
        }
        #endregion

        #region Methods
        private void OnClickEasyButton()
        {
            GameActions.OnChangeCurrentLevelType?.Invoke(LevelType.Easy);
            OnChangeCurentSelectedButton(easyButton);
        }
        private void OnClickMediumButton()
        {
            GameActions.OnChangeCurrentLevelType?.Invoke(LevelType.Medium);
            OnChangeCurentSelectedButton(mediumButton);
        }
        private void OnClickHardButton()
        {
            GameActions.OnChangeCurrentLevelType?.Invoke(LevelType.Hard);
            OnChangeCurentSelectedButton(hardButton);
        }

        private void OnChangeCurentSelectedButton(Button currentButton)
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            for (int i=0;i<levelSelectionButtons.Count;i++)
            {
                if (levelSelectionButtons[i] == currentButton)
                {
                    levelSelectionButtons[i].interactable = false;
                    currentLevelSelectionButton = levelSelectionButtons[i];
                }
                else
                    levelSelectionButtons[i].interactable = true;
            }
        }

        private void SetAllButtonsInteractable( bool val)
        {
            if (!val)
            {
                for (int i = 0; i < levelSelectionButtons.Count; i++)
                    levelSelectionButtons[i].interactable = val;              
            }
            else
            {
                for (int i = 0; i < levelSelectionButtons.Count; i++)
                    levelSelectionButtons[i].interactable = val;
                currentLevelSelectionButton.interactable = false;
            }
        }
        #endregion
    }
}