using Actions;
using Enums;
using Provider.Manager;
using System.Collections;
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
        [SerializeField] private Button backToMainMenuButton;
        [SerializeField] private Button easyButton;
        [SerializeField] private Button mediumButton;
        [SerializeField] private Button hardButton;
        [SerializeField] private Button defaultLevelButton;
        [SerializeField] private LevelType defaultLevelType;

        private List<Button> levelSelectionButtons = new List<Button>();
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            backToMainMenuButton.onClick.AddListener(OnClickBackButton);
            easyButton.onClick.AddListener(OnClickEasyButton);
            mediumButton.onClick.AddListener(OnClickMediumButton);
            hardButton.onClick.AddListener(OnClickHardButton);
            levelSelectionButtons.Add(easyButton);
            levelSelectionButtons.Add(mediumButton);
            levelSelectionButtons.Add(hardButton);
            OnChangeCurentSelectedButton(defaultLevelButton);
            GameActions.OnChangeCurrentLevelType?.Invoke(defaultLevelType);
        }

        private void OnDisable()
        {
            backToMainMenuButton?.onClick.RemoveListener(OnClickBackButton);
            easyButton?.onClick.RemoveListener(OnClickEasyButton);
            mediumButton?.onClick.RemoveListener(OnClickMediumButton);
            hardButton?.onClick.RemoveListener(OnClickHardButton);
            levelSelectionButtons.Clear();
        }
        #endregion

        #region Methods
        private void OnClickBackButton()
        {
            ManagerProvider.Instance.ScenesManager.LoadMainMenu();
        }

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
            for(int i=0;i<levelSelectionButtons.Count;i++)
            {
                if (levelSelectionButtons[i] == currentButton)
                {
                    levelSelectionButtons[i].GetComponent<Image>().canvasRenderer.SetAlpha(0.95f);
                    levelSelectionButtons[i].interactable = false;
                }
                else
                {
                    levelSelectionButtons[i].GetComponent<Image>().canvasRenderer.SetAlpha(1f);
                    levelSelectionButtons[i].interactable = true;
                }
            }
        }
        #endregion
    }
}