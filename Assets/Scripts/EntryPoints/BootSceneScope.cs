using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer.Unity;
using VContainer;
using Cysharp.Threading.Tasks;

namespace Abyss
{
    public class BootSceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
        }

        protected override async void Awake()
        {
            base.Awake();
            // Addressablesの初期化をawaitで待つ
            await Addressables.InitializeAsync().ToUniTask();

            // DIからSceneLoaderを解決してMainシーンへ遷移
            var loader = Container.Resolve<SceneLoader>();
            await loader.LoadSceneAsync("Main");
        }
    }

}
