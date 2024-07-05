using Data.Colour;
using Data.Shapes;
using UnityEngine;

namespace Data.Block
{
    /// <summary>
    /// Contains a block data
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Block/Create New Block",fileName ="Block")]
    public class BlockCreator : ScriptableObject
    {
        #region Variables
        public ShapeCreator Shape;
        public ColourCreator Colour;
        #endregion
    }
}