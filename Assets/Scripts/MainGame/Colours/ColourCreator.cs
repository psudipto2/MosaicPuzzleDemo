using Enums;
using UnityEngine;

namespace Data.Colour
{
    /// <summary>
    /// Colour Data
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Colour/Create New Colour", fileName = "Colour")]
    public class ColourCreator : ScriptableObject
    {
        #region Variables
        public ColourName Colour;
        public Color Color;
        #endregion
    }
}