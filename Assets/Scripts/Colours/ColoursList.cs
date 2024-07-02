using System.Collections.Generic;
using UnityEngine;

namespace Data.Colour
{
    /// <summary>
    /// Colour Data List
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Colour/Create New Colour List", fileName = "Colour List")]
    public class ColourList : ScriptableObject
    {
        #region Variables
        public List<ColourCreator> colours;
        #endregion
    }
}