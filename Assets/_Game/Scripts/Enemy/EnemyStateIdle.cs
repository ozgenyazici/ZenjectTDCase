using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenject.TD
{
    public class EnemyStateIdle : IEnemyState
    {
        readonly EnemyBuilder _builder;

        Vector3 _startPos;

        public void EnterState()
        {
            _startPos = _builder.Position;
        }

        public void ExitState()
        {
        }

        public void FixedUpdate()
        {
        }

        public void Update()
        {
            _builder.Position = _startPos * Time.deltaTime;
        }
    }
}