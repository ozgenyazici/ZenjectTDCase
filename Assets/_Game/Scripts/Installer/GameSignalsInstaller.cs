
using UnityEngine;
namespace Zenject.TD
{
    public class EnemyDiedSignalObserver
    {
        public void OnEnemyDied()
        {

        }
    }

    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EnemyKilledSignal>();

            Container.BindSignal<EnemyKilledSignal>().ToMethod<EnemyDiedSignalObserver>(x => x.OnEnemyDied).FromNew();
        }
    }


}
