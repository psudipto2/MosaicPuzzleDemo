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
        [SerializeField] private BlockRow allBlockList;

        private List<BlockController> blockPool;
        private List<BlockController> tileBlocks;
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
            CreateBlockPool();
        }
        #endregion

        #region Methods
        public void CreateTile(TileCreator tileCreator)
        {
            interactableBlocks = new List<BlockController>();
            tileBlocks = new List<BlockController>();
            gridLayoutGroup.cellSize = new Vector2(rectTransform.rect.width / tileCreator.Tile[0].Blocks.Count, rectTransform.rect.height / tileCreator.Tile.Count);
            for (int i = 0; i < tileCreator.Tile.Count; i++)
            {
                for (int j = 0; j < tileCreator.Tile[i].Blocks.Count; j++)
                {
                    BlockController blockController = GetBlockFromPool(tileCreator.Tile[i].Blocks[j]);
                    if (tileCreator.Tile[i].Blocks[j] != null)
                    {
                        interactableBlocks.Add(blockController);
                    }
                    tileBlocks.Add(blockController);
                }
            }

            if (interactableBlocks.Count == 0)
            {
                for (int i = 0; i < blockPool.Count; i++)
                {
                    if (blockPool[i].CheckBlockActive())
                        interactableBlocks.Add(blockPool[i]);
                }
                isBlankTile = true;
            }

            for(int i=0;i<tileBlocks.Count;i++)
                tileBlocks[i].SetBlockIndex(i);

            ManagerProvider.Instance.MainGameManager.BlocksWin = interactableBlocks.Count;
        }

        private void CreateBlockPool()
        {
            blockPool = new List<BlockController>();
            for (int i=0;i<allBlockList.Blocks.Count;i++)
            { 
                GameObject blockView = Instantiate(blockViewPrefab);
                blockView.transform.SetParent(transform);
                blockPool.Add(GetBlock(allBlockList.Blocks[i], blockView.GetComponent<BlockView>()));
                blockView.SetActive(false);
            }
        }

        private BlockController GetBlockFromPool(BlockCreator block)
        {
            for (int i = 0; i < blockPool.Count; i++)
            {
                if (!blockPool[i].CheckBlockActive())
                {
                    if (blockPool[i].BlockModel.Block == block)
                    {
                        blockPool[i].ToggleBlockView(true);
                        return blockPool[i];
                    }
                }
            }

            GameObject blockView = Instantiate(blockViewPrefab);
            blockView.transform.SetParent(transform);
            BlockController blockController = GetBlock(block, blockView.GetComponent<BlockView>());
            blockPool.Add(blockController);
            return blockController;

        }

        private BlockController GetBlock(BlockCreator block, BlockView blockView)
        {
            BlockModel blockModel = new BlockModel(block);
            BlockController blockController = new BlockController(blockModel, blockView);
            return blockController;
        }

        public void ResetTile()
        {
            for(int i=0; i<interactableBlocks.Count; i++)
                interactableBlocks[i].ResetBlock();
            ManagerProvider.Instance.MainGameManager.BlocksWin = interactableBlocks.Count;
        }

        public void DestroyTile()
        {
            for(int i=0;i<blockPool.Count; i++)
            {
                if (blockPool[i].CheckBlockActive())
                {
                    blockPool[i].ResetBlockView();
                    blockPool[i].ToggleBlockView(false);
                }
            }
        }
        #endregion
    }
}