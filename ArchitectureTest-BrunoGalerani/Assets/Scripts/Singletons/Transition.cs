using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singletons
{
    [RequireComponent(typeof(Animator))]
    public class Transition : MonoBehaviour, ITransition
    {
        private static readonly int Show = Animator.StringToHash("Show");

        [Header("Set in Editor")] [SerializeField]
        private AnimationClip showAnimationClip;

        private Coroutine _coroutine;
        private Animator _animator;
        private Animator Animator => _animator ??= GetComponent<Animator>();

        public void LoadScene(string sceneName)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(LoadSceneWithTransition(sceneName));
            }
        }

        private IEnumerator LoadSceneWithTransition(string sceneName)
        {
            Animator.SetTrigger(Show);
            yield return new WaitForSeconds(showAnimationClip.length);
            SceneManager.LoadScene(sceneName);
            yield return new WaitForSeconds(showAnimationClip.length);
            _coroutine = null;
        }
    }
}