using Actions;
using Data.Block;
using Data.Tile;
using Enums;
using Manager.MainGame;
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
        #endregion

        #region Unity Methods
        private void Awake()
        {
            GameManager.Instance.TileManager = this;
            
        }

        private void Start()
        {
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
            rectTransform = GetComponent<RectTransform>();
            float cellWidth = rectTransform.rect.width / tileCreator.Tile[0].Blocks.Count;
            float cellHeight = rectTransform.rect.height / tileCreator.Tile.Count;
            gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
            CreateTile();
        }
        #endregion

        #region Methods
        private void CreateTile()
        {
            for (int i = 0; i < tileCreator.Tile.Count; i++)
            {
                for (int j = 0; j < tileCreator.Tile[i].Blocks.Count; j++)
                {
                    GameObject blockView = Instantiate(blockViewPrefab);
                    blockView.transform.SetParent(transform);
                    CreateNewBlock(tileCreator.Tile[i].Blocks[j], blockView.GetComponent<BlockView>());
                }
            }
        }

        private void CreateNewBlock(BlockCreator block, BlockView blockView)
        {
            BlockModel blockModel = new BlockModel(block);
            BlockController blockController = new BlockController(blockModel, blockView);

            blockControllers.Add(blockController);
            if (block != null)
                interactableBlockCount++;
        }

        public void CheckWin(int inDeAmount)
        {
            interactableBlockCount += inDeAmount;
            if (interactableBlockCount == 0)
                Debug.Log("Game Won");
        }
        #endregion
    }
}