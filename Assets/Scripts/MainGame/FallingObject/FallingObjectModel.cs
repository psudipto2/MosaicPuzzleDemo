using UnityEngine;

namespace MVC.FallingObject
{
    /// <summary>
    /// Model of falling object
    /// </summary>
    public class FallingObjectModel
    {
        #region Variables
        public Sprite ObjectSprite;
        public Color ObjectColor;
        #endregion

        #region Constructor
        public FallingObjectModel(Sprite objectSprite, Color objectColor)
        {
            ObjectSprite = objectSprite;
            ObjectColor = objectColor;
        }
        #endregion
    }
}