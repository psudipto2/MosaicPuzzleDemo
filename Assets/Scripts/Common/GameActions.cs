using Data.Block;
using Data.Colour;
using Data.Shapes;
using System;

namespace Actions
{
    /// <summary>
    /// Contains all game actions
    /// </summary>
    public class GameActions
    {
        #region Actions
        public static Action<ColourCreator> OnChangeColour;
        public static Action<ShapeCreator> OnChangeShape;
        public static Action<bool> OnClickRightBlock;

        public static Action OnClickWrongBlock;
        #endregion
    }
}
