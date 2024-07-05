using System.Collections.Generic;
using UnityEngine;
using Provider.Manager;
using Enums;
using Actions;
using Data.Level;
using MVC.Level;
using UnityEngine.UI;

namespace Manager.Level
{
    /// <summary>
    /// Manages all levels in the game
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject levelViewPrefab;
        [SerializeField] private GameObject levelSelectionPanel;
        [SerializeField] private LevelList levelList;
        [SerializeField] private AudioClip sfxClip;

        private LevelType currentLevelType;
        private LevelData currentLevel;
        private List<LevelController> levelControllers = new List<LevelController>();
        private GridLayoutGroup gridLayoutGroup;
        private RectTransform rectTransform;
        #endregion

        #region Properties
        public LevelData CurrentLevel {  get { return currentLevel; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.LevelManager = this;
            GameActions.OnChangeCurrentLevelType += OnChangeCurrentLevelType;
            GameActions.OnSelectLevel += OnSelectLevel;
        }

        private void Start()
        {
            gridLayoutGroup = levelSelectionPanel.GetComponent<GridLayoutGroup>();
            rectTransform = levelSelectionPanel.GetComponent<RectTransform>();
            CreateAllLevels();
        }

        private void OnDestroy()
        {
            GameActions.OnChangeCurrentLevelType -= OnChangeCurrentLevelType;
            GameActions.OnSelectLevel -= OnSelectLevel;
        }
        #endregion

        #region Methods
        private void OnChangeCurrentLevelType(LevelType levelType)
        {
            int currentLevelTypeLevelCount = 0;
            int gridRowCount;
            List<LevelController> currentTypeControllers = new List<LevelController>();

            currentLevelType = levelType;
            for (int i = 0; i < levelControllers.Count; i++)
            {
                if (levelControllers[i].LevelModel.LevelType == levelType)
                {
                    currentLevelTypeLevelCount++;
                    currentTypeControllers.Add(levelControllers[i]);
                }
                else
                    levelControllers[i].ToggleLevelView(false);
            }

            if (currentLevelTypeLevelCount % 2 == 0)
                gridRowCount = currentLevelTypeLevelCount / 2;
            else
                gridRowCount = (currentLevelTypeLevelCount / 2) + 1;

            gridLayoutGroup.cellSize = new Vector2(rectTransform.rect.width / gridRowCount, gridLayoutGroup.cellSize.y);

            for(int i=0;i<currentTypeControllers.Count;i++)
                currentTypeControllers[i].ToggleLevelView(true);
        }

        private void OnSelectLevel(LevelData currentLevel)
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxClip);
            this.currentLevel = currentLevel;
            ManagerProvider.Instance.ScenesManager.LoadMainGame(this.currentLevel);
        }

        private void CreateAllLevels()
        {
            for(int i=0; i<levelList.Levels.Count; i++)
            {
                GameObject levelView = Instantiate(levelViewPrefab);
                levelView.transform.SetParent(levelSelectionPanel.transform, false);
                CreateNewLevel(levelList.Levels[i], levelView.GetComponent<LevelView>());
            }
        }

        private void CreateNewLevel(LevelData levelData, LevelView levelView)
        {
            LevelModel levelModel = new LevelModel(levelData);
            LevelController levelController = new LevelController(levelModel, levelView);
            levelControllers.Add(levelController);
        }
        #endregion
    }
}
