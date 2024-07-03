using System.Collections;
using UnityEngine;
using Singleton;
using Manager.Colour;
using Manager.Shapes;
using Manager.Tile;
using Manager.FallingObject;
using Manager.UI;
using Manager.Scenes;
using UnityEngine.SceneManagement;
using Manager.UI.Level;
using Manager.Level;

namespace Provider.Manager
{
    public class ManagerProvider : PersistentSingleton<ManagerProvider>
    {
        #region Variables
        private ScenesManager scenesManager;
        private LevelManager levelManager;
        private UIManager uiManager;
        private ColourManager colourManager;
        private ShapeManager shapeManager;
        private TileManager tileManager;
        private FallingObjectManager fallingObjectManager;
        #endregion

        #region Properties
        public ScenesManager ScenesManager { get { return scenesManager; } set { scenesManager = value; } }
        public LevelManager LevelManager { get { return levelManager; } set { levelManager = value; } }
        public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }
        public ColourManager ColourManager {  get { return colourManager; } set { colourManager = value; } }
        public ShapeManager ShapeManager { get { return shapeManager; } set { shapeManager = value; } }
        public TileManager TileManager { get { return tileManager; } set { tileManager = value; } }
        public FallingObjectManager FallingObjectManager { get { return fallingObjectManager; } set { fallingObjectManager = value; } }
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
