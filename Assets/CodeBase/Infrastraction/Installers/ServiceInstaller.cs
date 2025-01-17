using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Obstacle.Factory;
using CodeBase.Gameplay.Player.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Service.InputsService;
using CodeBase.UI;
using CodeBase.UI.Factory;
using CodeBase.UI.Service;
using Zenject;

namespace CodeBase.Infrastraction.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindUIFactory();
            BindUIService();
            BindGameFactory();
            BindCommonServices();
        }
    
        private void BindInputService() =>
            Container.Bind<IInputService>().To<InputService>().AsSingle();

        private void BindUIService()
        {
            Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();
            Container.Bind<IHudService>().To<HudService>().AsSingle();
        }
            

        private void BindUIFactory() => 
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

        private void BindGameFactory()
        {
            Container.Bind<IInstanceFactory>().To<InstanceFactory>().AsSingle();
            Container.Bind<IMeteoriteFactory>().To<MeteoriteFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<IArmamentsFactory>().To<ArmamentsFactory>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<IObstacleFactory>().To<ObstacleFactory>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IObjectPool>().To<ObjectPool>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }
    }
}