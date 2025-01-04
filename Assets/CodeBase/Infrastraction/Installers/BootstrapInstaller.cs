using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Logic;
using CodeBase.Infrastraction.Service;
using CodeBase.Infrastraction.States.Factory;
using UnityEngine;
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
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    }
}