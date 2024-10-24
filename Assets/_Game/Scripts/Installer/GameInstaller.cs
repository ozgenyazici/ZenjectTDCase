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

            Container.BindFactory<float, float, EnemyFacade, EnemyFacade.Factory>()
                .FromPoolableMemoryPool<float, float, EnemyFacade, EnemyFacadePool>(poolBinder => poolBinder
                   .WithInitialSize(2)
                   .FromSubContainerResolve()
                   .ByNewPrefabInstaller<EnemyInstaller>(_settings.EnemyFacadePrefab)
                   .UnderTransformGroup("Enemies")
                );

           Container.BindFactory<Vector3, Transform, TurretFacade, TurretFacade.Factory>()
                .FromComponentInNewPrefab(_settings.TurretPrefab)
                .UnderTransformGroup("Turrets");

            //Container.BindFactory<Vector3, Transform, Turret,Turret.Factory>().FromComponentInNewPrefab(_settings.Tur).AsTransient();

            Container.BindFactory<float, float, BulletTypes, Bullet, Bullet.Factory>()
                .FromPoolableMemoryPool<float, float, BulletTypes, Bullet, BulletPool>(poolBinder => poolBinder
                    .WithInitialSize(20)
                    .FromComponentInNewPrefab(_settings.BulletPrefab)
                    .UnderTransformGroup("Bullets"));

            Container.Bind<EnemyRegistry>().AsSingle();
            Container.Bind<TurretRegistry>().AsSingle();

            Container.Bind<TurretSpawner>().AsSingle();
            Container.Bind<TurretManager>().AsSingle();

            Container.Bind<TurretShop>().AsSingle();

            GameSignalsInstaller.Install(Container);
        }

        [Serializable]
        public class Settings
        {
            public GameObject EnemyFacadePrefab;
            public GameObject BulletPrefab;
            public GameObject TurretPrefab;
            public GameObject TurretFirePrefab;
        }

        class EnemyFacadePool : MonoPoolableMemoryPool<float, float, IMemoryPool, EnemyFacade>
        {
        }

        class BulletPool : MonoPoolableMemoryPool<float, float, BulletTypes, IMemoryPool, Bullet>
        {
        }

    }
}