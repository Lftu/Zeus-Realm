using Zenject;

namespace Game
{
    public class DataCollectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSessionData>().FromInstance(new GameSessionData()).AsSingle();
        }
    }
}