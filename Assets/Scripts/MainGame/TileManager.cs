using Data.Block;
using Data.Tile;
using Provider.Manager;
using MVC.Block;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Tile
{
    public class TileManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject blockViewPrefab;

        private List<BlockController> blockControllers;
        private List<BlockController> interactableBlocks;
        private GridLayoutGroup gridLayoutGroup;
        private RectTransform rectTransform;
        private bool isBlankTile = false;
        #endregion

        #region Properties
        public bool IsBlankTile {  get { return isBlankTile; } set { isBlankTile = value; } }
        #endregion

        #region Unity Methods
        private void Awake()
        { 
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
            rectTransform = GetComponent<RectTransform>();
        }
        #endregion

        #region Methods
        public void CreateTile(TileCreator tileCreator)
        {
            blockControllers = new List<BlockController>();
            interactableBlocks = new List<BlockController>();
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

            if (interactableBlocks.Count == 0)
            {
                interactableBlocks = blockControllers;
                isBlankTile = true;
            }
            ManagerProvider.Instance.MainGameManager.BlocksWin = interactableBlocks.Count;
        }

        private void CreateNewBlock(BlockCreator block, BlockView blockView)
        {
            BlockModel blockModel = new BlockModel(block);
            BlockController blockController = new BlockController(blockModel, blockView);

            blockControllers.Add(blockController);
            if (block != null)
                interactableBlocks.Add(blockController);
        }

        public void ResetTile()
        {
            for(int i=0; i<interactableBlocks.Count; i++)
                interactableBlocks[i].ResetBlock();
            ManagerProvider.Instance.MainGameManager.BlocksWin = interactableBlocks.Count;
        }

        public void DestroyTile()
        {
            for(int i=0; i<blockControllers.Count; i++)
            {
                blockControllers[i].DestroyBlock();
            }
            blockControllers.Clear();
            interactableBlocks.Clear();
        }
        #endregion
    }
}