using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Level
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private List<AssetReference> levels;

        public int LevelsAmount => levels.Count;

        /// <summary>
        /// Try loading the level asynchronously using <see cref="Addressables"/>.
        /// </summary>
        /// <param name="levelIndex">The level to be loaded.</param>
        /// <param name="onSuccess">Callback for when the level is successfully loaded.</param>
        /// <param name="onFailure">Callback for when the level couldn't be loaded.</param>
        public void LoadLevelAsync(int levelIndex, Action<LevelScriptableObject> onSuccess,
            Action onFailure)
        {
            if (levelIndex >= 0 && levelIndex < levels.Count)
            {
                var asyncHandle =
                    Addressables.LoadAssetAsync<LevelScriptableObject>(levels[levelIndex]);
                asyncHandle.Completed +=
                    handle => OnLevelLoadCompleted(handle, onSuccess, onFailure);
            }
            else
            {
                onFailure?.Invoke();
            }
        }

        private static void OnLevelLoadCompleted(AsyncOperationHandle<LevelScriptableObject> handle,
            Action<LevelScriptableObject> onSuccess, Action onFailure)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                onSuccess?.Invoke(handle.Result);
            }
            else
            {
                onFailure?.Invoke();
            }
        }
    }
}