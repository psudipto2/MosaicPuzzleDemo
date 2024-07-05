using Data.Block;
using UnityEngine;

namespace MVC.Block
{
    /// <summary>
    /// Model of block MVC
    /// </summary>
    public class BlockModel
    {
        #region Variables
        public Sprite FilledSprite;
        public Sprite BlankSprite;
        public Color Color;
        public BlockCreator Block;
        #endregion

        #region Constructor
        public BlockModel(BlockCreator block)
        {
            Block = block;
            if (block != null )
            {
                FilledSprite = block.Shape.FilledSprite;
                BlankSprite = block.Shape.BlankSprite;
                Color = block.Colour.Color;
            }
        }
        #endregion
    }
}