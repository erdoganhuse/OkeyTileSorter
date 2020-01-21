using Core.Controller;
using Signals;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller<MainInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
            
            Container.DeclareSignal<GameStartedSignal>();
        }
    }
}