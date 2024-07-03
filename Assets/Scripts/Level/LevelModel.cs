using Data.Level;
using Data.Tile;
using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Level 
{ 
    /// <summary>
    /// Model of Level MVC
    /// </summary>
    public class LevelModel
    {
        #region Variables
        public LevelType LevelType;
        public string LevelName;
        public Sprite LevelSprite;
        public TileCreator Tile;
        public LevelData LevelData;
        #endregion

        #region Constructor
        public LevelModel(LevelData levelData)
        {
            LevelData = levelData;
            LevelType = levelData.LevelType;
            LevelName = levelData.Name;
            LevelSprite = levelData.LevelSprite;
            Tile = levelData.Tile;
        }
        #endregion
    }
}