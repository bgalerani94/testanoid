using JetBrains.Annotations;
using Singletons;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class responsible for moving objects using Physics.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputMovementController : MonoBehaviour
    {
        [Header("Set in Editor")] [SerializeField]
        private float speed;

        private Rigidbody2D _rigidbody2D;
        private bool _isPressingLeft;
        private bool _isPressingRight;
        private bool _isMobile;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _isMobile = SingletonComponent<AppController>.Instance.IsMobile();
        }

        private void Update()
        {
            if (!_isMobile)
            {
                var horizontal = Input.GetAxisRaw("Horizontal");
                _isPressingLeft = Mathf.Approximately(horizontal, -1);
                _isPressingRight = Mathf.Approximately(horizontal, 1);
            }
        }

        private void FixedUpdate()
        {
            if (_isPressingLeft)
            {
                _rigidbody2D.velocity = Vector2.left * speed;
            }
            else if (_isPressingRight)
            {
                _rigidbody2D.velocity = Vector2.right * speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        [UsedImplicitly]
        public void OnLeftPressed(bool pressed)
        {
            _isPressingLeft = pressed;
        }

        [UsedImplicitly]
        public void OnRightPressed(bool pressed)
        {
            _isPressingRight = pressed;
        }
    }
}