using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BrickController : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public event Action OnDestroyed;

        private void OnDestroy()
        {
            OnDestroyed = null;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                _rigidbody2D.isKinematic = true;
                _boxCollider2D.enabled = false;
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}