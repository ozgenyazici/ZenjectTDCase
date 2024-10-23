
using UnityEngine;
namespace Zenject.TD
{
    public enum BulletTypes
    {
        FromTower
    }
    public class Bullet : MonoBehaviour, IPoolable<float, float, BulletTypes, IMemoryPool>
    {
        float _startTime;
        BulletTypes _type;
        float _speed;
        float _lifeTime; // will be add.
        int _damage;

        [SerializeField]
        MeshRenderer _renderer = null;

        [SerializeField]
        Material _enemyMaterial = null;

        IMemoryPool _pool;

        public BulletTypes Type
        {
            get { return _type; }
        }

        public Vector3 MoveDirection
        {
            get { return transform.right; }
        }

        public void OnTriggerEnter(Collider col)
        {
            var enemy = col.GetComponent<EnemyBuilder>();

            if (enemy != null && _type == BulletTypes.FromTower)
            {
                enemy.Facade.TakeDamage(_damage);
                _pool.Despawn(this);
            }
        }

        public void Update()
        {
            transform.position -= transform.right * _speed * Time.deltaTime;

        }
        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(float speed, float lifeTime, BulletTypes type, IMemoryPool pool)
        {
            _pool = pool;
            _type = type;
            _speed = speed;
            _lifeTime = lifeTime;

            _renderer.material = _enemyMaterial;

            _startTime = Time.realtimeSinceStartup;
        }
        public class Factory : PlaceholderFactory<float, float, BulletTypes, Bullet>
        {
        }
    }
}
