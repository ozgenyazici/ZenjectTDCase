using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModestTree;

namespace Zenject.TD
{
    public interface IEnemyState
    {
        void EnterState();
        void ExitState();
        void Update();
        void FixedUpdate();
    }
    public enum EnemyStates
    {
        Idle,
        Walk,
        None
    }

    public class EnemyStateManager : ITickable, IFixedTickable, IInitializable
    {

        IEnemyState _currentStateHandler;
        EnemyStates _currentState = EnemyStates.None;

        EnemyBuilder _builder;

        List<IEnemyState> _states;

        [Inject]
        public void Construct(EnemyBuilder builder, EnemyStateIdle idle, EnemyStateWalk walk)
        {

            _builder = builder;
            _states = new List<IEnemyState> { idle, walk };
        }
        public void Initialize()
        {
            Assert.IsEqual(_currentState, EnemyStates.None);
            Assert.IsNull(_currentStateHandler);

            ChangeState(EnemyStates.Idle);
        }

        public void ChangeState(EnemyStates state)
        {
            if (_currentState == state)
                return;

            _currentState = state;

            if (_currentStateHandler != null)
            {
                _currentStateHandler.ExitState();
                _currentStateHandler = null;
            }

            _currentStateHandler = _states[(int)state];
            _currentStateHandler.EnterState();
        }
        public void Tick()
        {
            _currentStateHandler.Update();
        }

        public void FixedTick()
        {
            _currentStateHandler.FixedUpdate();
        }



        public EnemyStates CurrentState
        {
            get { return _currentState; }
        }
    }

}