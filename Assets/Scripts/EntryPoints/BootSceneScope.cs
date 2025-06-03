using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer.Unity;
using VContainer;

namespace Abyss
{
    public class BootSceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //builder.Register<SceneLoader>(Lifetime.Singleton);
        }

        protected override void Awake()
        {
            base.Awake();
            Addressables.InitializeAsync().Completed += handle =>
            {
                //var loader = Container.Resolve<SceneLoader>();
                //loader.LoadSceneAsync("MainScene");
            };
        }
    }

}
