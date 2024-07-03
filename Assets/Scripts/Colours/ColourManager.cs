using System.Collections.Generic;
using UnityEngine;
using Actions;
using Provider.Manager;
using Data.Colour;
using MVC.Colour;

namespace Manager.Colour
{
    /// <summary>
    /// Manages all the colours in the game
    /// </summary>
    public class ColourManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ColourCreator defaultColour;
        [SerializeField] private ColourList allColourList;
        [SerializeField] private GameObject colourViewPrefab;

        private ColourCreator currentColour;
        private List<ColourController> colourControllers;
        #endregion

        #region Properties
        public ColourCreator CurrentColour { get { return currentColour; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.ColourManager = this;
            colourControllers = new List<ColourController>();
            GameActions.OnChangeColour += OnColourChange;
        }

        private void Start()
        {
            CreateAllColours();
        }

        private void OnDestroy()
        {
            GameActions.OnChangeColour -= OnColourChange;
        }
        #endregion

        #region Methods
        private void OnColourChange(ColourCreator colour)
        {
            currentColour = colour;
        }

        private void CreateNewColour(ColourCreator colour, ColourView colourView)
        {
            ColourModel colourModel = new ColourModel(colour);
            ColourController colourController = new ColourController(colourView, colourModel);

            if (colour == defaultColour)
                colourController.SelectColour();
            colourControllers.Add(colourController);
        }

        private void CreateAllColours()
        {
            for(int i=0; i < allColourList.colours.Count; i++)
            {
                GameObject colourView = Instantiate(colourViewPrefab);
                colourView.transform.SetParent(transform);
                CreateNewColour(allColourList.colours[i], colourView.GetComponent<ColourView>());
            }
        }
        #endregion
    }
}
