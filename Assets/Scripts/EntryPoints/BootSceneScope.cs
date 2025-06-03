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
            // Addressables�̏�������await�ő҂�
            await Addressables.InitializeAsync().ToUniTask();

            // DI����SceneLoader����������Main�V�[���֑J��
            var loader = Container.Resolve<SceneLoader>();
            await loader.LoadSceneAsync("Main");
        }
    }

}
