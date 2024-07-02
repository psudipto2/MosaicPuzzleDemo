using Actions;
using Data.Colour;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Colour
{
    /// <summary>
    /// View of colour MVC
    /// </summary>
    public class ColourView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Image highlighter;
        [SerializeField] private Image colourImage;

        private Button button;
        private ColourController colourController;
        #endregion

        #region Properties
        public ColourController ColourController { set { colourController = value; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            GameActions.OnChangeColour += SetHighlighter;
        }

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(colourController.SelectColour);
            colourController.ApplyColour();
        }

        private void OnDestroy()
        {
            GameActions.OnChangeColour -= SetHighlighter;
        }
        #endregion

        #region Methods
        public void ApplyColour(Color color)
        {
            colourImage.color = color;
        }

        private void SetHighlighter(ColourCreator colour)
        {
            if (colour == colourController.ColourModel.Colour)
                highlighter.gameObject.SetActive(true);
            else
                highlighter.gameObject.SetActive(false);
        }
        #endregion
    }
}