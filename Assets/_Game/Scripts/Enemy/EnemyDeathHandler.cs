using System;
using UnityEngine;


namespace Zenject.TD
{
    public class EnemyDeathHandler : MonoBehaviour
    {
        readonly EnemyFacade _facade;
        readonly SignalBus _signalBus;
        readonly EnemyBuilder _builder;


        public EnemyDeathHandler(EnemyFacade facade, SignalBus signalBus, EnemyBuilder builder)
        {
            _facade = facade;
            _signalBus = signalBus;
            _builder = builder;
        }

        public void Die()
        {
            _signalBus.Fire<EnemyKilledSignal>();
            _facade.Dispose();
        }
    }
}
