using Actions;
using Enums;
using Provider.Manager;
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
            if(ManagerProvider.Instance.MainGameManager.TileManager.IsBlankTile)
                CheckBlockOnBlankTile();
            else
                CheckBlockOnFilledTile();
        }

        private void CheckBlockOnBlankTile()
        {
            Sprite currentSprite = ManagerProvider.Instance.MainGameManager.ShapeManager.CurrentShape.FilledSprite;
            Color currentColor = ManagerProvider.Instance.MainGameManager.ColourManager.CurrentColour.Color;
            if (!blockFilled)
            {
                blockModel.FilledSprite = currentSprite;
                blockModel.Color = currentColor;
                GameActions.OnPlaceBlock?.Invoke();
                blockView.ToggleImageOnBlankTile(true);
                blockFilled = true;
            }
            else
            {
                if(blockModel.FilledSprite==currentSprite && blockModel.Color == currentColor)
                {
                    GameActions.OnRemoveBlock?.Invoke();
                    blockView.ToggleImageOnBlankTile(false);
                    blockFilled = false;
                }
                else
                {
                    if (blockModel.Color != currentColor)
                        blockModel.Color = currentColor;
                    if (blockModel.FilledSprite != currentSprite)
                        blockModel.FilledSprite = currentSprite;
                    blockView.ToggleImageOnBlankTile(true);
                }
            }
        }

        private void CheckBlockOnFilledTile()
        {
            if (blockModel.Block != null && ManagerProvider.Instance.MainGameManager.ColourManager.CurrentColour == blockModel.Block.Colour && ManagerProvider.Instance.MainGameManager.ShapeManager.CurrentShape == blockModel.Block.Shape)
            {
                if (!blockFilled)
                {
                    GameActions.OnPlaceBlock?.Invoke();
                    blockView.ToggleImage(BlockType.Filled);
                    blockFilled = true;
                }
                else
                {
                    GameActions.OnRemoveBlock?.Invoke();
                    blockView.ToggleImage(BlockType.Blank);
                    blockFilled = false;
                }
            }
            else
                GameActions.OnPlaceWrongBlock?.Invoke(blockView.gameObject.transform, blockView.gameObject.GetComponent<RectTransform>());
                
        }

        public void ResetBlock()
        {
            if (ManagerProvider.Instance.MainGameManager.TileManager.IsBlankTile)
            {
                blockView.ToggleImageOnBlankTile(false);
                blockFilled = false;
            }
            else
            {
                blockView.ToggleImage(BlockType.Blank);
                blockFilled = false;
            }
        }

        public void DestroyBlock()
        {
            blockView.DestroyView();
            blockModel = null;
        }
        #endregion
    }
}