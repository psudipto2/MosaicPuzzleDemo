using Manager.MainGame;
using MVC.FallingObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.FallingObject
{
    /// <summary>
    /// Manages the object which falls on wrong block selection
    /// </summary>
    public class FallingObjectManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject fallingObjectViewPrefab;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            GameManager.Instance.FallingObjectManager = this;
        }
        #endregion

        #region Methods
        public void CreateNewFallingObject(Transform transform, RectTransform rectTransform)
        {
            GameObject fallingObjectView = Instantiate(fallingObjectViewPrefab,this.transform);
            fallingObjectView.transform.position = transform.position;
            fallingObjectView.GetComponent<RectTransform>().sizeDelta = rectTransform.sizeDelta;

            FallingObjectModel fallingObjectModel = new FallingObjectModel(GameManager.Instance.ShapeManager.CurrentShape.FilledSprite, GameManager.Instance.ColourManager.CurrentColour.Color);
            FallingObjectController fallingObjectController = new FallingObjectController(fallingObjectModel, fallingObjectView.GetComponent<FallingObjectView>());
        }
        #endregion
    }
}
