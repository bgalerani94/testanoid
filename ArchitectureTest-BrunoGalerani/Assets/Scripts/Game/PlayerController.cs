using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(InputMovementController))]
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _initialPos;

        private void Awake()
        {
            _initialPos = transform.position;
        }

        public void ResetPosition()
        {
            transform.position = _initialPos;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball") && other.enabled)
            {
                var ball = other.gameObject.GetComponent<BallController>();
                var directionModifier = CalculateBallDirectionModifier(ball.transform.position);
                ball.SetVelocity(directionModifier);
            }
        }

        /// <summary>
        /// Calculates the modifier to be applied to the ball direction according to the point that
        /// the ball has hit the player.
        /// </summary>
        /// <param name="ballPos">The current position of the ball.</param>
        /// <returns>The modifier value based on the point that the ball has hit the player.</returns>
        private Vector3 CalculateBallDirectionModifier(Vector3 ballPos)
        {
            var playerPos = transform.position;
            var newVelocity = new Vector2(ballPos.x - playerPos.x, ballPos.y - playerPos.y);
            return newVelocity;
        }
    }
}