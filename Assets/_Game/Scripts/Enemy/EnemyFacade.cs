using System;
using UnityEngine;
namespace Zenject.TD
{
    public class EnemyFacade : MonoBehaviour, IPoolable<float, float, IMemoryPool>, IDisposable
    {
        EnemyBuilder _builder;
        EnemyStat _stats;
        IMemoryPool _pool;

        [Inject]
        public void Construct(EnemyBuilder builder, EnemyStat stats)
        {
            _builder = builder;
            _stats = stats;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
        public void OnSpawned(float health, float speed, IMemoryPool pool)
        {
            _pool = pool;
            _stats.speed = speed;
            _stats.health = health;

        }
        public float Speed
        {
            get { return _stats.speed; }
        }
        public float Health
        {
            get { return _stats.health; }
        }
        public Vector3 Position
        {
            get { return _builder.Position; }
            set { _builder.Position = value; }
        }
        public void OnDead()
        {

        }
        public void TakeDamage(int damage)
        {

        }
        public void OnDespawned()
        {
            _pool = null;

        }

        public class Factory : PlaceholderFactory<float, float, EnemyFacade>
        {
        }
    }
}