using Actions;
using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Block
{
    /// <summary>
    /// View of block MVC
    /// </summary>
    public class BlockView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Image filledImage;
        [SerializeField] private Image blankImage;

        private Button button;
        private BlockController blockController;
        #endregion

        #region Properties
        public BlockController BlockController { set { blockController = value; } }
        #endregion

        #region Unity Methods
        private void Start()
        {
            button = GetComponent<Button>();
            GetComponent<RectTransform>().localScale = Vector3.one;
            blankImage.sprite = blockController.BlockModel.BlankSprite;
            blankImage.color = blockController.BlockModel.Color;
            filledImage.sprite = blockController.BlockModel.FilledSprite;
            filledImage.color = blockController.BlockModel.Color;
            button.onClick.AddListener(blockController.CheckBlock);
            if (blockController.BlockModel.Block != null)
                ToggleImage(BlockType.Blank);
            GameActions.OnSetMainGameButtonsInteractable += SetButtonInteractable;
        }

        private void OnDestroy()
        {
            GameActions.OnSetMainGameButtonsInteractable -= SetButtonInteractable;
        }
        #endregion

        #region Methods
        public void ToggleImage(BlockType blockType)
        {
            switch(blockType)
            {
                case BlockType.Filled:
                    blankImage.gameObject.SetActive(false);
                    filledImage.gameObject.SetActive(true);
                    break;
                case BlockType.Blank:
                    filledImage.gameObject.SetActive(false);
                    blankImage.gameObject.SetActive(true);
                    break;
            }
        }

        public void ToggleImageOnBlankTile(bool place)
        {
            if (place)
            {
                filledImage.sprite = blockController.BlockModel.FilledSprite;
                filledImage.color= blockController.BlockModel.Color;
            }
            filledImage.gameObject.SetActive(place);
        }

        private void SetButtonInteractable(bool val)
        {
            button.interactable = val;
        }

        public void ResetView()
        {
            filledImage.gameObject.SetActive(false);
            if(blockController.BlockModel.Block!=null)
                blankImage.gameObject.SetActive(true);
        }
        #endregion
    }
}