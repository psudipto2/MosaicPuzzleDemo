using Actions;

namespace MVC.Shape
{
    /// <summary>
    /// Controller of shape MVC
    /// </summary>
    public class ShapeController
    {
        #region Variables
        private ShapeModel shapeModel;
        private ShapeView shapeView;
        #endregion

        #region Properties
        public ShapeModel ShapeModel { get { return shapeModel; } }
        #endregion

        #region Constructor
        public ShapeController(ShapeModel shapeModel, ShapeView shapeView)
        {
            this.shapeModel = shapeModel;
            this.shapeView = shapeView;
            this.shapeView.ShapeController = this;
        }
        #endregion

        #region Methods
        public void ApplyShape()
        {
            shapeView.ApplyShape(shapeModel.Sprite);
        }

        public void SelectShape()
        {
            GameActions.OnPlaySFXAudio?.Invoke(shapeView.SfxClip);
            GameActions.OnChangeShape?.Invoke(shapeModel.Shape);
        }
        #endregion
    }
}