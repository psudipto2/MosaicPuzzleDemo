using System.Collections.Generic;
using UnityEngine;

namespace Data.Block
{
    /// <summary>
    /// Row data of a tile
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Block/Create New Block Row", fileName = "Block Row")]
    public class BlockRow : ScriptableObject
    {
        #region
        public List<BlockCreator> Blocks = new List<BlockCreator>();
        #endregion
    }
}