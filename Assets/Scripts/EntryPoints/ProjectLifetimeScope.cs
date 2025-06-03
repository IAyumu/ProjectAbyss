using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Abyss
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneLoader>(Lifetime.Singleton);
            //builder.Register<GameManager>(Lifetime.Singleton);
        }

        private static ProjectLifetimeScope _instance;

        protected override void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("[ProjectScope] Duplicate detected, destroying self.");
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            base.Awake(); // VContainerÇÃèâä˙âªÇÕÇ±Ç±
        }
    }
}
