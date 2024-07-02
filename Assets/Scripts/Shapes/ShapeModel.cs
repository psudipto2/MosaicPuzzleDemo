using Data.Shapes;
using UnityEngine;

namespace MVC.Shape
{
    /// <summary>
    /// Model of Shape MVC
    /// </summary>
    public class ShapeModel
    {
        #region Variables
        public ShapeCreator Shape;
        public Sprite Sprite;
        #endregion

        #region Constructor
        public ShapeModel(ShapeCreator shapeCreator)
        {
            Shape = shapeCreator;
            Sprite = shapeCreator.FilledSprite;
        }
        #endregion
    }
}