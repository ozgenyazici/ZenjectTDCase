using System;
using UnityEngine;
namespace Zenject.TD
{
    public class TurretFacade : MonoBehaviour//, IPoolable<Vector3, Transform, IMemoryPool>, IDisposable
    {
        TurretBuilder _builder;
        TurretRegistry _registry;
        TurretStat _stat;
        IMemoryPool _pool;

        [Inject]
        public void Construct(
            TurretBuilder builder,
            TurretRegistry registry,
            TurretStat stat)
        {
            _builder = builder;
            _registry = registry;
            _stat = stat;
        }

        public float FireRate
        {
            get { return _stat.fireRate; }
        }

        public Vector3 Position
        {
            get { return _builder.Position; }
            set { _builder.Position = value; }
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _registry.RemoveTurret(this);
            _pool = null;
        }

        public void OnSpawned(float fireRate,float a , IMemoryPool pool)
        {
            _pool = pool;
            _stat.fireRate = fireRate;
        }


        public class Factory : PlaceholderFactory<Vector3, Transform, TurretFacade>
        {
        }
    }

}
