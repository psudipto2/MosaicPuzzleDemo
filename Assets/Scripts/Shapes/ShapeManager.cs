using Actions;
using Data.Shapes;
using Manager.MainGame;
using MVC.Shape;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Shapes
{
    /// <summary>
    /// Manages all the shapes in the game
    /// </summary>
    public class ShapeManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ShapeCreator defaultShape;
        [SerializeField] private ShapeList allShapeList;
        [SerializeField] private GameObject shapeViewPrefab;

        private ShapeCreator currentShape;
        private List<ShapeController> shapeControllers;
        #endregion

        #region Properties
        public ShapeCreator CurrentShape { get { return currentShape; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            GameManager.Instance.ShapeManager = this;
            shapeControllers = new List<ShapeController>();
            GameActions.OnChangeShape += OnShapeChange;
        }

        private void Start()
        {
            CreateAllShapes();
        }

        private void OnDestroy()
        {
            GameActions.OnChangeShape -= OnShapeChange;
        }
        #endregion

        #region Methods
        public void OnShapeChange(ShapeCreator shape)
        {
            currentShape = shape;
        }

        private void CreateNewShape(ShapeCreator shape, ShapeView shapeView)
        {
            ShapeModel shapeModel = new ShapeModel(shape);
            ShapeController shapeController=new ShapeController(shapeModel, shapeView);

            if (shape == defaultShape)
                shapeController.SelectShape();
            shapeControllers.Add(shapeController);
        }

        private void CreateAllShapes()
        {
            for (int i = 0; i < allShapeList.Shapes.Count; i++)
            {
                GameObject shapeView = Instantiate(shapeViewPrefab);
                shapeView.transform.SetParent(transform);
                CreateNewShape(allShapeList.Shapes[i], shapeView.GetComponent<ShapeView>());
            }
        }
        #endregion
    }
}