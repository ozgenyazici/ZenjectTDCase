using System;
using UnityEngine;

namespace Zenject.TD
{
    [CreateAssetMenu(fileName = "TD", menuName = "TD/Game Settings", order = 1)]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public EnemySpawner.Settings EnemySpawner;
        public EnemySettings Enemy;
        public class EnemySettings
        {
            public EnemyStat DefaultSettings;
            public EnemyStateIdle EnemyStateIdle;
        }
    }
}