using Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Level
{
    /// <summary>
    /// View of level MVC
    /// </summary>
    public class LevelView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Image levelImage;
        [SerializeField] private TMP_Text levelName;
        [SerializeField] private Button levelButton;

        private LevelController levelController;
        #endregion

        #region Properties
        public LevelController LevelController { set { levelController = value; } }
        #endregion

        #region Unity Methods
        private void Start()
        {
            levelImage.sprite = levelController.LevelModel.LevelSprite;
            levelName.text = levelController.LevelModel.LevelName;
            levelButton.onClick.AddListener(levelController.LoadLevel);
        }

        private void Awake()
        {
            GameActions.OnSetLevelMenuButtonsInteractable += SetButtonInteractable;
        }

        private void OnDestroy()
        {
            GameActions.OnSetLevelMenuButtonsInteractable -= SetButtonInteractable;
        }
        #endregion

        #region Methods
        private void SetButtonInteractable(bool val)
        {
            levelButton.interactable = val;
        }
        #endregion
    }
}