using Provider.Manager;
using MVC.FallingObject;
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
            
        }

        private void OnDestroy()
        {
            
        }
        #endregion

        #region Methods
        public void CreateNewFallingObject(Transform transform, RectTransform rectTransform)
        {
            GameObject fallingObjectView = Instantiate(fallingObjectViewPrefab,this.transform);
            fallingObjectView.transform.position = transform.position;
            fallingObjectView.GetComponent<RectTransform>().sizeDelta = rectTransform.sizeDelta;

            FallingObjectModel fallingObjectModel = new FallingObjectModel(ManagerProvider.Instance.MainGameManager.ShapeManager.CurrentShape.FilledSprite, ManagerProvider.Instance.MainGameManager.ColourManager.CurrentColour.Color);
            FallingObjectController fallingObjectController = new FallingObjectController(fallingObjectModel, fallingObjectView.GetComponent<FallingObjectView>());
        }
        #endregion
    }
}
