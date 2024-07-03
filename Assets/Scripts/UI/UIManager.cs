using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using Provider.Manager;
using Manager.UI.MainMenu;
using Manager.UI.Level;

namespace Manager.UI
{
    /// <summary>
    /// Manages whole UI related stuffs in the title
    /// </summary>
    public class UIManager : PersistentSingleton<UIManager>
    {
        #region Variables
        [SerializeField] private MainMenuManager mainMenuManager;
        [SerializeField] private LevelUIManager levelUIManager;
        #endregion

        #region Properties
        public MainMenuManager MainMenuManager { get { return mainMenuManager; } }
        public LevelUIManager LevelUIManager { get { return levelUIManager; } }
        #endregion

        #region Unity Methods
        protected override void Awake()
        {
            base.Awake();
            ManagerProvider.Instance.UIManager = this;
        }
        #endregion
    }
}
