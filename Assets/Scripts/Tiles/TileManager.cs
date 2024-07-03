using Actions;
using Data.Block;
using Data.Tile;
using Enums;
using Provider.Manager;
using MVC.Block;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Tile
{
    public class TileManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TileCreator tileCreator;
        [SerializeField] private GameObject blockViewPrefab;

        private List<BlockController> blockControllers = new List<BlockController>();
        private GridLayoutGroup gridLayoutGroup;
        private RectTransform rectTransform;
        private int interactableBlockCount;
        private bool isBlankTile = false;
        #endregion

        #region Properties
        public bool IsBlankTile {  get { return isBlankTile; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.TileManager = this;
            GameActions.OnPlaceBlock += OnPlaceBlock;
            GameActions.OnRemoveBlock += OnRemoveBlock;
        }

        private void Start()
        {
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
            rectTransform = GetComponent<RectTransform>();
            CreateTile(ManagerProvider.Instance.LevelManager.CurrentLevel.Tile);
        }

        private void OnDestroy()
        {
            GameActions.OnPlaceBlock -= OnPlaceBlock;
            GameActions.OnRemoveBlock -= OnRemoveBlock;
        }
        #endregion

        #region Methods
        public void CreateTile(TileCreator tileCreator)
        {
            gridLayoutGroup.cellSize = new Vector2(rectTransform.rect.width / tileCreator.Tile[0].Blocks.Count, rectTransform.rect.height / tileCreator.Tile.Count);
            for (int i = 0; i < tileCreator.Tile.Count; i++)
            {
                for (int j = 0; j < tileCreator.Tile[i].Blocks.Count; j++)
                {
                    GameObject blockView = Instantiate(blockViewPrefab);
                    blockView.transform.SetParent(transform);
                    CreateNewBlock(tileCreator.Tile[i].Blocks[j], blockView.GetComponent<BlockView>());
                }
            }

            if (interactableBlockCount == 0)
            {
                interactableBlockCount = tileCreator.Tile.Count * tileCreator.Tile[0].Blocks.Count;
                isBlankTile = true;
            }
            Debug.Log(interactableBlockCount);
        }

        private void CreateNewBlock(BlockCreator block, BlockView blockView)
        {
            BlockModel blockModel = new BlockModel(block);
            BlockController blockController = new BlockController(blockModel, blockView);

            blockControllers.Add(blockController);
            if (block != null)
                interactableBlockCount++;
        }

        private void OnPlaceBlock()
        {
            interactableBlockCount--;
            if (interactableBlockCount == 0)
                Debug.Log("Game Won");
        }

        private void OnRemoveBlock()
        {
            interactableBlockCount++;
        }
        #endregion
    }
}