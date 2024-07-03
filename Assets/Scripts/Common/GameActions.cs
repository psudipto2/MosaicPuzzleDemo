using Data.Block;
using Data.Colour;
using Data.Level;
using Data.Shapes;
using Enums;
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
        public static Action<LevelType> OnChangeCurrentLevelType;
        public static Action<LevelData> OnSelectLevel;
        public static Action OnPlaceBlock;
        public static Action OnRemoveBlock;
        public static Action<bool> OnClickRightBlock;
        public static Action OnPlaceWrongBlock;
        public static Action OnGameWon;
        #endregion
    }
}
