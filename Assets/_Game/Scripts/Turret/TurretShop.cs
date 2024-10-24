using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenject.TD {
    public class TurretShop
    {
        readonly Turret _turret;
        public TurretShop(Turret turret)
        {
            _turret = turret;
        }
    }
}