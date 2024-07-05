using System.Collections;
using UnityEngine;
using Singleton;
using Manager.UI;
using Manager.Scenes;
using UnityEngine.SceneManagement;
using Manager.Level;
using Manager.Sound;
using Manager.MainGame;

namespace Provider.Manager
{
    public class ManagerProvider : PersistentSingleton<ManagerProvider>
    {
        #region Variables
        private ScenesManager scenesManager;
        private LevelManager levelManager;
        private UIManager uiManager;
        private SoundManager soundManager;
        private MainGameManager mainGameMaanger;
        #endregion

        #region Properties
        public ScenesManager ScenesManager { get { return scenesManager; } set { scenesManager = value; } }
        public LevelManager LevelManager { get { return levelManager; } set { levelManager = value; } }
        public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }
        public SoundManager SoundManager { get { return soundManager; } set { soundManager = value; } }
        public MainGameManager MainGameManager { get { return mainGameMaanger; } set { mainGameMaanger = value; } }
        #endregion

        #region Unity Methods
        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(CompleteBooting());           
        }
        #endregion

        #region Methods
        private IEnumerator CompleteBooting()
        {
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene(1);
        }
        #endregion
    }
}
