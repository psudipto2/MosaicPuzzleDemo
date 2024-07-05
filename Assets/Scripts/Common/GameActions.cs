using Data.Colour;
using Data.Level;
using Data.Shapes;
using Enums;
using System;
using UnityEngine;

namespace Actions
{
    /// <summary>
    /// Contains all game actions
    /// </summary>
    public class GameActions
    {
        #region UI
        public static Action<bool> OnSetMainGameButtonsInteractable;
        public static Action<bool> OnSetLevelMenuButtonsInteractable;
        public static Action OnExitGame;
        #endregion

        #region Sound
        public static Action<bool> OnMusicStatusChange;
        public static Action<bool> OnSfxStatusChange;
        public static Action<AudioClip> OnPlaySFXAudio;
        #endregion

        #region Level
        public static Action<LevelType> OnChangeCurrentLevelType;
        public static Action OnLoadLevelMenu;
        public static Action<LevelData> OnSelectLevel;
        #endregion Level

        #region Main Game
        public static Action<ColourCreator> OnChangeColour;
        public static Action<ShapeCreator> OnChangeShape;
        public static Action<Transform, RectTransform> OnPlaceWrongBlock;
        public static Action OnPlaceBlock;
        public static Action OnRemoveBlock;
        #endregion

        #region Game Manager
        public static Action OnLevelRestart;
        public static Action<LevelData> OnLevelStart;
        public static Action OnLevelWin;
        public static Action OnLeaveMainGame;
        #endregion
    }
}
