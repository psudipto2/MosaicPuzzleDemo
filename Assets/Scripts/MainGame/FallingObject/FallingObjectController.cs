using UnityEngine;

namespace MVC.FallingObject 
{
    /// <summary>
    /// Controller of failling object
    /// </summary>
    public class FallingObjectController
    {
        #region Variables
        private FallingObjectModel fallingObjectModel;
        private FallingObjectView fallingObjectView;
        #endregion

        #region Properties
        public FallingObjectModel FallingObjectModel {  get { return fallingObjectModel; } }
        #endregion

        #region Constructor
        public FallingObjectController(FallingObjectModel fallingObjectModel,FallingObjectView fallingObjectView)
        {
            this.fallingObjectModel = fallingObjectModel;
            this.fallingObjectView = fallingObjectView;
            this.fallingObjectView.FallingObjectController = this;
        }
        #endregion

        #region Methods
        public float GetFallingOffset()
        {
            int direction = Random.Range(0, 3);
            float offset = Random.Range(100f, 120f);
            switch (direction)
            {
                case 1:
                    return offset;
                case 2:
                    return offset * -1;
            }
            return 0f;
        }

        public void Destroy()
        {
            fallingObjectModel = null;
            fallingObjectView = null;
        }
        #endregion
    }
}