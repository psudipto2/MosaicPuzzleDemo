using UnityEngine;
using UnityEngine.UI;

namespace MVC.FallingObject
{
    /// <summary>
    /// View of falling object MVC
    /// </summary>
    public class FallingObjectView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Image objectImage;

        private Rigidbody2D rigidbody;
        private BoxCollider2D boxCollider;
        private FallingObjectController fallingObjectController;
        #endregion

        #region Properties
        public FallingObjectController FallingObjectController { set { fallingObjectController = value; } }
        #endregion

        #region Unity Methods
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
            ApplyImage();
            Invoke(nameof(ApplyForce), 0.25f);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            fallingObjectController.Destroy();
        }
        #endregion

        #region Methods
        private void ApplyImage()
        {
            objectImage.sprite = fallingObjectController.FallingObjectModel.ObjectSprite;
            objectImage.color = fallingObjectController.FallingObjectModel.ObjectColor;
        }

        private void ApplyForce()
        {
            rigidbody.velocity = new Vector2((rigidbody.velocity.x + fallingObjectController.GetFallingOffset()), Random.Range(200f,300f));
        }

        public void Destroy(FallingObjectController fallingObjectController)
        {
            Destroy(gameObject);
            fallingObjectController = null;
        }
        #endregion
    }
}
