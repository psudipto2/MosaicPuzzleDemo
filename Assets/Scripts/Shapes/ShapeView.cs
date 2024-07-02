using Actions;
using Data.Colour;
using Data.Shapes;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Shape
{
    /// <summary>
    /// View of shape MVC
    /// </summary>
    public class ShapeView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Image highlighter;
        [SerializeField] private Image shapeImage;

        private Button button;
        private ShapeController shapeController;
        #endregion

        #region Properties
        public ShapeController ShapeController { set { shapeController = value; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            GameActions.OnChangeShape += SetHighlighter;
            GameActions.OnChangeColour += ApplyColour;
        }

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(shapeController.SelectShape);
            shapeController.ApplyShape();
        }

        private void OnDestroy()
        {
            GameActions.OnChangeShape -= SetHighlighter;
            GameActions.OnChangeColour -= ApplyColour;
        }
        #endregion

        #region Methods
        public void ApplyShape(Sprite sprite)
        {
            shapeImage.sprite = sprite;
        }

        private void ApplyColour(ColourCreator colour)
        {
            shapeImage.color = colour.Color;
        }

        private void SetHighlighter(ShapeCreator shape)
        {
            if(shape==shapeController.ShapeModel.Shape)
                highlighter.gameObject.SetActive(true);
            else 
                highlighter.gameObject.SetActive(false);
        }
        #endregion
    }
}