using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Abyss
{
    public class SceneLoader
    {
        public async UniTask LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single, CancellationToken ct = default)
        {
            Debug.Log($"[SceneLoader] Loading scene: {sceneName}");

            // アドレスでシーンロード
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(sceneName, mode, true);
            await handle.ToUniTask(cancellationToken: ct);

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"[SceneLoader] Failed to load scene: {sceneName}");
            }
            else
            {
                Debug.Log($"[SceneLoader] Loaded scene: {sceneName}");
            }
        }

        public async UniTask UnloadSceneAsync(string sceneName, CancellationToken ct = default)
        {
            Debug.Log($"[SceneLoader] Unloading scene: {sceneName}");

            Scene scene = SceneManager.GetSceneByName(sceneName);
            if (scene.isLoaded)
            {
                AsyncOperation op = SceneManager.UnloadSceneAsync(scene);
                await op.ToUniTask(cancellationToken: ct);
                Debug.Log($"[SceneLoader] Unloaded scene: {sceneName}");
            }
            else
            {
                Debug.LogWarning($"[SceneLoader] Scene not loaded: {sceneName}");
            }
        }
    }

}