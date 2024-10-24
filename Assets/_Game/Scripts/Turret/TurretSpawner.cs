using System;
using ModestTree;
using UnityEngine;
namespace Zenject.TD
{
    public class TurretSpawner 
    {
        readonly TurretFacade.Factory _turretFactory;
        readonly SignalBus _signalBus;
        Transform pos;
        public TurretSpawner(
            SignalBus signalBus,
            TurretFacade.Factory turretFactory
            )
        {
            _turretFactory = turretFactory;
            _signalBus = signalBus;
        }

        public void SpawnTurret(Vector3 point)
        {
            var turretFacade = _turretFactory.Create(point, pos);
        }
    }

}
