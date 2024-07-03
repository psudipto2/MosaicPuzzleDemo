using UnityEngine;
using Data.Block;
using System.IO;
using UnityEditor;
using System.Collections.Generic;
using Enums;

namespace Data.Tile
{
    /// <summary>
    /// Level Tile Creator
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Tile/Create New Tile", fileName = "Tile")]
    public class TileCreator : ScriptableObject
    {
        #region Variables
        public List<BlockRow> Tile;
        #endregion
    }
}