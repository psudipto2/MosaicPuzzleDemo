using Actions;
using Enums;
using Manager.MainGame;
using UnityEngine;

namespace MVC.Block
{
    /// <summary>
    /// Controller of block MVC
    /// </summary>
    public class BlockController
    {
        #region Variables
        private BlockModel blockModel;
        private BlockView blockView;
        private bool blockFilled;
        #endregion

        #region Constructor
        public BlockController(BlockModel blockModel, BlockView blockView)
        {
            this.blockModel = blockModel;
            this.blockView = blockView;
            this.blockView.BlockController = this;
            blockFilled = false;
        }
        #endregion

        #region Properties
        public BlockModel BlockModel { get { return this.blockModel; } }
        #endregion

        #region Methods
        public void CheckBlock()
        {
            if (blockModel.Block != null && GameManager.Instance.ColourManager.CurrentColour == blockModel.Block.Colour && GameManager.Instance.ShapeManager.CurrentShape == blockModel.Block.Shape)
            {
                if (!blockFilled)
                {
                    GameActions.OnClickRightBlock?.Invoke(true);
                    blockView.ToggleImage(BlockType.Filled);
                    GameManager.Instance.TileManager.CheckWin(-1);
                    blockFilled = true;
                }
                else
                {
                    GameActions.OnClickRightBlock?.Invoke(false);
                    blockView.ToggleImage(BlockType.Blank);
                    GameManager.Instance.TileManager.CheckWin(1);
                    blockFilled = false;
                }
            }
            else
            {
                GameActions.OnClickWrongBlock?.Invoke();
                GameManager.Instance.FallingObjectManager.CreateNewFallingObject(blockView.gameObject.transform,blockView.gameObject.GetComponent<RectTransform>());
            }
        }
        #endregion
    }
}