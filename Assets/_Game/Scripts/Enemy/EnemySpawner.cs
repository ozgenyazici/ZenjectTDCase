using System;
using ModestTree;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zenject.TD
{
    public class EnemySpawner : ITickable, IInitializable
    {
        readonly EnemyFacade.Factory _enemyFactory;
        readonly Settings _settings;
        readonly SignalBus _signalBus;

        public EnemySpawner(Settings settings,
            SignalBus signalBus,
            EnemyFacade.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _settings = settings;
            _signalBus = signalBus;
        }

        float _desiredNumEnemies;
        int _enemyCount;
        float _lastSpawnTime;

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyKilledSignal>(OnEnemyKilled);
        }

        void SpawnEnemy()
        {
            float speed = Random.Range(_settings.SpeedMin, _settings.SpeedMax);
            float accuracy = Random.Range(_settings.AccuracyMin, _settings.AccuracyMax);

            var enemyFacade = _enemyFactory.Create(accuracy, speed);
            //enemyFacade.Position=this


            _lastSpawnTime = Time.realtimeSinceStartup;
        }
        public void Tick()
        {
            _desiredNumEnemies += _settings.NumEnemiesIncreaseRate * Time.deltaTime;

            if (_enemyCount < (int)_desiredNumEnemies
                && Time.realtimeSinceStartup - _lastSpawnTime > _settings.DelayBetweenSpawns)
            {
                SpawnEnemy();
                _enemyCount++;
            }
        }



        void OnEnemyKilled()
        {
            _enemyCount--;
        }

        [Serializable]
        public class Settings
        {
            public float SpeedMin;
            public float SpeedMax;

            public float AccuracyMin;
            public float AccuracyMax;

            public float NumEnemiesIncreaseRate;
            public float NumEnemiesStartAmount;

            public float DelayBetweenSpawns = 0.5f;
        }
    }

   
}