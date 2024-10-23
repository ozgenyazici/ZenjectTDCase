using System;
using UnityEngine;
namespace Zenject.TD
{
    public class GameInstaller : MonoInstaller
    {
        [Inject]
        Settings _settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();

            Container.BindFactory<float, float, EnemyFacade, EnemyFacade.Factory>().
                FromPoolableMemoryPool<float, float, EnemyFacade, EnemyFacadePool>(poolBinder => poolBinder
                   .WithInitialSize(2)
                   .FromSubContainerResolve()
                   .ByNewPrefabInstaller<EnemyInstaller>(_settings.EnemyFacadePrefab)
                   .UnderTransformGroup("Enemies")
                );


            Container.BindFactory<float, float, BulletTypes, Bullet, Bullet.Factory>()
                .FromPoolableMemoryPool<float, float, BulletTypes, Bullet, BulletPool>(poolBinder => poolBinder
                    
                    .WithInitialSize(20)
                
                    .FromComponentInNewPrefab(_settings.BulletPrefab)
                    .UnderTransformGroup("Bullets"));
            
        }

        [Serializable]
        public class Settings
        {
            public GameObject EnemyFacadePrefab;
            public GameObject BulletPrefab;
        }

        class EnemyFacadePool : MonoPoolableMemoryPool<float, float, IMemoryPool, EnemyFacade>
        {
        }

        class BulletPool : MonoPoolableMemoryPool<float, float, BulletTypes, IMemoryPool, Bullet>
        {
        }

    }
}