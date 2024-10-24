using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenject.TD
{
    public class EnemyStateWalk : IEnemyState
    {
        readonly EnemyBuilder _builder;

        private Transform _target;
        private int _wavePointIndex = 0;

        public EnemyStateWalk(EnemyBuilder builder)
        {
            _builder = builder;
        }
		

		void GetNextWaypoint()
		{
			if (_wavePointIndex >= Waypoints.points.Length - 1)
			{
				EndPath();
				return;
			}

			_wavePointIndex++;
			_target = Waypoints.points[_wavePointIndex];
		}

		void EndPath()
		{
			
			WaveSpawner.EnemiesAlive--;
			
		}
		public void EnterState()
        {
        }

        public void ExitState()
        {
        }

        public void FixedUpdate()
        {
        }

        public void Update()
        {
			Vector3 dir = _target.position - _builder.transform.position;
			_builder.transform.Translate(dir.normalized * 5 * Time.deltaTime, Space.World);

			if (Vector3.Distance(_builder.transform.position, _target.position) <= 0.4f)
			{
				GetNextWaypoint();
			}

			// _builder.Position = _startPos * Time.deltaTime;
		}
	}
}