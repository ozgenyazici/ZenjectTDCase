using System.Collections.Generic;

namespace Zenject.TD
{
    public class TurretRegistry
    {
        readonly List<TurretFacade> _turrets = new List<TurretFacade>();

        public IEnumerable<TurretFacade> Turrets
        {
            get { return _turrets; }
        }

        public void AddTurret(TurretFacade turret)
        {
            _turrets.Add(turret);
        }

        public void RemoveTurret(TurretFacade turret)
        {
            _turrets.Remove(turret);
        }
    }
}
