namespace Zenject.TD
{
    public class TurretInstaller : Installer<TurretInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<TurretStat>().AsSingle();

        }
    }
}