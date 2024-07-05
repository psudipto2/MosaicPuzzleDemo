using Actions;
using Data.Level;
using Manager.Colour;
using Manager.FallingObject;
using Manager.Shapes;
using Manager.Tile;
using Manager.UI.PausePanel;
using Provider.Manager;
using System.Collections;
using UnityEngine;

namespace Manager.MainGame
{
    /// <summary>
    /// Manages main game
    /// </summary>
    public class MainGameManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ColourManager colourManager;
        [SerializeField] private ShapeManager shapeManager;
        [SerializeField] private TileManager tileManager;
        [SerializeField] private FallingObjectManager fallingObjectManager;
        [SerializeField] private MainGamePausePanel mainGamePausePanel;
        [SerializeField] private AudioClip sfxPlaceBlockClip;
        [SerializeField] private AudioClip sfxRemoveBlockClip;
        [SerializeField] private AudioClip sfxPlaceWrongBlockClip;
        [SerializeField] private AudioClip sfxStartLevelClip;
        [SerializeField] private AudioClip sfxGameWinClip;

        private int blocksToWin;
        #endregion

        #region Properties
        public ColourManager ColourManager { get { return colourManager; } set { colourManager = value; } }
        public ShapeManager ShapeManager { get { return shapeManager; } set { shapeManager = value; } }
        public TileManager TileManager { get { return tileManager; } set { tileManager = value; } }
        public FallingObjectManager FallingObjectManager { get { return fallingObjectManager; } set { fallingObjectManager = value; } }
        public int BlocksWin { set { blocksToWin= value; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.MainGameManager = this;
            GameActions.OnPlaceBlock += OnPlaceBlock;
            GameActions.OnRemoveBlock += OnRemoveBlock;
            GameActions.OnPlaceWrongBlock += OnPlaceWrongBlock;
            GameActions.OnLevelStart += StartLevel;
            GameActions.OnLevelRestart += RestartLevel;
            GameActions.OnLeaveMainGame += ResetAll;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            GameActions.OnPlaceBlock -= OnPlaceBlock;
            GameActions.OnRemoveBlock -= OnRemoveBlock;
            GameActions.OnPlaceWrongBlock -= OnPlaceWrongBlock;
            GameActions.OnLevelRestart -= RestartLevel;
            GameActions.OnLevelStart -= StartLevel;
            GameActions.OnLeaveMainGame -= ResetAll;
        }
        #endregion

        #region Methods
        private void StartLevel(LevelData levelData)
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxStartLevelClip);
            ResetCurrentBlock();
            tileManager.CreateTile(levelData.Tile);
        }

        private void RestartLevel()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxStartLevelClip);
            ResetCurrentBlock();
            tileManager.ResetTile();
        }

        private void ResetCurrentBlock()
        {
            GameActions.OnChangeShape?.Invoke(shapeManager.DefaultShape);
            GameActions.OnChangeColour?.Invoke(colourManager.DefaultColour);
        }

        private void ResetAll()
        {
            ResetCurrentBlock();
            tileManager.DestroyTile();
            tileManager.IsBlankTile = false;
        }

        private void OnPlaceBlock()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxPlaceBlockClip);
            blocksToWin--;
            if (blocksToWin == 0)
            {
                GameActions.OnLevelWin?.Invoke();
                StartCoroutine(OnWinLevel());
            }
            Debug.Log(blocksToWin);
        }

        private void OnRemoveBlock()
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxRemoveBlockClip);
            blocksToWin++;
            Debug.Log(blocksToWin);
        }

        private void OnPlaceWrongBlock(Transform transform, RectTransform rectTransform)
        {
            GameActions.OnPlaySFXAudio?.Invoke(sfxPlaceWrongBlockClip);
            ManagerProvider.Instance.MainGameManager.FallingObjectManager.CreateNewFallingObject(transform, rectTransform);

        }
        private IEnumerator OnWinLevel()
        {
            yield return new WaitForSeconds(0.5f);
            GameActions.OnPlaySFXAudio?.Invoke(sfxGameWinClip);
            mainGamePausePanel.IsGameWinView = true;
            //Hack Fix for pause panel not coming up at first time
            mainGamePausePanel.gameObject.SetActive(true);
            mainGamePausePanel.gameObject.SetActive(true);
        }
        #endregion
    }
}
