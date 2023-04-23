using System;
using Scripts.Utils;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // синхронная загрузка - плохо потому что подвисает игра
            var playerPrefab = Resources.Load<Player>("Player");
            builder.RegisterComponentInNewPrefab<Player>(playerPrefab, Lifetime.Scoped);
            
            // асинхронная загрузка - хорошо потому что не подвисает игра
            
            
            // builder.RegisterComponentOnNewGameObject<Player>(Lifetime.Scoped);
            // builder.RegisterComponentInHierarchy<Zombie>();

            builder.RegisterNpcFactories();


            builder.Register<ZombieSpawner>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerHpManager>(Lifetime.Scoped);
            builder.Register<DbConnection>(Lifetime.Transient).AsImplementedInterfaces();


            // что происходит автомитически
            // var container = (builder as ContainerBuilder).Build();
            // var phpm = container.Resolve<PlayerHpManager>();
        }
    }
}