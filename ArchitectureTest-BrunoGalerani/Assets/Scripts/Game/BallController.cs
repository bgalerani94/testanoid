using Extensions;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class BallController : MonoBehaviour
    {
        [Header("Set in Editor")] [SerializeField]
        private float speed = 6f;

        [SerializeField] [Range(.1f, 1f)] private float kickVariationX;
        [SerializeField] [Range(.1f, 1f)] private float kickVariationY;

        private Rigidbody2D _rigidbody2D;
        private CircleCollider2D _circleCollider2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void FixedUpdate()
        {
            SetVelocity(_rigidbody2D.velocity);
        }

        public void SetVelocity(Vector3 velocity)
        {
            _rigidbody2D.velocity = velocity.normalized * speed;
        }

        public void Show(bool show)
        {
            _circleCollider2D.enabled = show;
            gameObject.SetActive(show);
        }

        public void ResetPosition()
        {
            SetVelocity(Vector2.zero);
            transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Throws the ball to the bottom of the screen with a random angle.
        /// </summary>
        public void PerformInitialKick()
        {
            var randomX = Random.Range(kickVariationX, 1 - kickVariationX);
            randomX.RandomlyApplyNegation();
            var randomY = Random.Range(-1, -kickVariationY);
            var randomVelocity = new Vector2(randomX, randomY);
            SetVelocity(randomVelocity);
        }
    }
}