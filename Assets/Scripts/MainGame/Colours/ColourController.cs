using Actions;

namespace MVC.Colour
{
    /// <summary>
    /// Controller of colour MVC
    /// </summary>
    public class ColourController
    {
        #region Variables
        private ColourView colourView;
        private ColourModel colourModel;
        #endregion

        #region Properties
        public ColourModel ColourModel { get { return colourModel; } }
        #endregion

        #region Constructor
        public ColourController(ColourView colourView, ColourModel colourModel) 
        {
            this.colourView = colourView;
            this.colourModel = colourModel;
            this.colourView.ColourController = this;
        }
        #endregion

        #region Methods
        public void ApplyColour()
        {
            colourView.ApplyColour(colourModel.Color);
        }

        public void SelectColour()
        {
            GameActions.OnPlaySFXAudio?.Invoke(colourView.SfxClip);
            GameActions.OnChangeColour?.Invoke(colourModel.Colour);
        }
        #endregion
    }
}