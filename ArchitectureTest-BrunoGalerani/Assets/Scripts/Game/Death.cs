using System;
using UnityEngine;

namespace Game
{
    public class Death : MonoBehaviour
    {
        public event Action OnDeath;

        private void OnDestroy()
        {
            OnDeath = null;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnDeath?.Invoke();
        }
    }
}