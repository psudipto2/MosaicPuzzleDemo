using Actions;
using UnityEngine;

namespace MVC.Level
{
    /// <summary>
    /// Controller of level MVC
    /// </summary>
    public class LevelController
    {
        #region Variables
        private LevelModel levelModel;
        private LevelView levelView;
        #endregion

        #region Properties
        public LevelModel LevelModel {  get { return levelModel; } }
        #endregion

        #region Constructor
        public LevelController (LevelModel levelModel, LevelView levelView)
        {
            this.levelModel = levelModel;
            this.levelView = levelView;
            this.levelView.LevelController = this;
        }
        #endregion

        #region Methods
        public void LoadLevel()
        {
            GameActions.OnSelectLevel?.Invoke(levelModel.LevelData);
        }

        public void ToggleLevelView(bool val)
        {
            levelView.gameObject.SetActive(val);
            if (val )
                levelView.GetComponent<RectTransform>().localScale = Vector3.one;
        }
        #endregion
    }
}