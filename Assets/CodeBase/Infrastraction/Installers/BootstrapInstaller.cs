using CodeBase.Infrastraction.Loading;
using CodeBase.Infrastraction.States;
using CodeBase.Infrastraction.States.Factory;
using CodeBase.Infrastraction.States.GameStates;
using Zenject;

namespace CodeBase.Infrastraction.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindGameState();
            BindInfrastructureServices();
            BindStateFactory();
            BindSceneLoader();
           
        }

        private void BindGameStateMachine() => 
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

        private void BindSceneLoader() => 
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

        private void BindStateFactory() =>
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        
        private void BindInfrastructureServices() => 
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();

        private void BindGameState()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    }
}