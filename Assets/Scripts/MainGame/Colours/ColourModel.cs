using Data.Colour;
using UnityEngine;

namespace MVC.Colour
{
    /// <summary>
    /// Model of colour MVC
    /// </summary>
    public class ColourModel
    {
        #region Variables
        public ColourCreator Colour;
        public Color Color;
        #endregion

        #region Constructor
        public ColourModel(ColourCreator colour)
        {
            Colour = colour;
            Color = colour.Color;
        }
        #endregion
    }
}