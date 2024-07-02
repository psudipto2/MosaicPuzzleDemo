using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using Manager.Colour;
using Manager.Shapes;
using Manager.Tile;
using Manager.FallingObject;
using UnityEngine.SceneManagement;

namespace Manager.MainGame
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        #region Variables
        private ColourManager colourManager;
        private ShapeManager shapeManager;
        private TileManager tileManager;
        private FallingObjectManager fallingObjectManager;
        #endregion

        #region Properties
        public ColourManager ColourManager {  get { return colourManager; } set { colourManager = value; } }
        public ShapeManager ShapeManager { get { return shapeManager; } set { shapeManager = value; } }
        public TileManager TileManager { get { return tileManager; } set { tileManager = value; } }
        public FallingObjectManager FallingObjectManager { get { return fallingObjectManager; } set { fallingObjectManager = value; } }
        #endregion


        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(MoveToNextScene());
            
        }
        private IEnumerator MoveToNextScene()
        {
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene(1);
        }

    }
}
