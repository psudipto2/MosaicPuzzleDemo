using System.Collections.Generic;
using UnityEngine;

namespace Data.Shapes
{
    /// <summary>
    /// Shape Data List
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Shape/Create New Shape List", fileName = "ShapeList")]
    public class ShapeList : ScriptableObject
    {
        #region Variables
        public List<ShapeCreator> Shapes;
        #endregion
    }
}