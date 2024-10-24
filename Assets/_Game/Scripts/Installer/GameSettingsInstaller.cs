using System;
//using UnityEngine;

namespace Zenject.TD
{
    //  [CreateAssetMenu(fileName = "TD", menuName = "TD/Game Settings", order = 1)]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public EnemySpawner.Settings EnemySpawner;
        public GameInstaller.Settings GameInstaller;
        public EnemySettings Enemy;

        [Serializable]
        public class EnemySettings
        {
            public EnemyStat DefaultSettings;
            public EnemyStateIdle EnemyStateIdle;
            public EnemyStateWalk EnemyStateWalk;

        }

        public override void InstallBindings()
        {
            Container.BindInstance(EnemySpawner).IfNotBound();

            Container.BindInstance(GameInstaller).IfNotBound();

            Container.BindInstance(Enemy.EnemyStateIdle).IfNotBound();

            Container.BindInstance(Enemy.EnemyStateWalk).IfNotBound();

        }
    }
}