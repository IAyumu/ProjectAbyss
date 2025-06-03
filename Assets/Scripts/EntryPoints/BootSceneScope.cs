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
            // Addressables‚Ì‰Šú‰»‚ğawait‚Å‘Ò‚Â
            await Addressables.InitializeAsync().ToUniTask();

            // DI‚©‚çSceneLoader‚ğ‰ğŒˆ‚µ‚ÄMainƒV[ƒ“‚Ö‘JˆÚ
            var loader = Container.Resolve<SceneLoader>();
            await loader.LoadSceneAsync("Main");
        }
    }

}
