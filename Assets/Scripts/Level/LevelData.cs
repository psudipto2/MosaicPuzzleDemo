using Data.Tile;
using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Level
{
    /// <summary>
    /// Data of a level
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Level/Create New Level", fileName = "Level")]
    public class LevelData : ScriptableObject
    {
        public LevelType LevelType;
        public Sprite LevelSprite;
        public string Name;
        public TileCreator Tile;
    }
}