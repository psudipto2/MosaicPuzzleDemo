using System.Collections.Generic;
using UnityEngine;

namespace Data.Level
{
    /// <summary>
    /// List of level datas
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Level/Create New Level List", fileName = "LevelList")]
    public class LevelList : ScriptableObject
    {
        #region Variables
        public List<LevelData> Levels = new List<LevelData>();
        #endregion
    }
}