using Enums;
using UnityEngine;

namespace Data.Shapes
{
    /// <summary>
    /// Shape Data
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Shape/Create New Shape", fileName = "Shape")]
    public class ShapeCreator : ScriptableObject
    {
        #region Variables
        public ShapeName Name;
        public Sprite FilledSprite;
        public Sprite BlankSprite;
        #endregion
    }
}