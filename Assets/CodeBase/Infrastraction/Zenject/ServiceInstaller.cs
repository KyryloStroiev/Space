using CodeBase.Infrastraction.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStaticDataService();
        BindPlayerFactory();
        BindGameFactory();
        BindObjectPool();
        BindMeteoriteFactory();
        BindUIFactory();
        BindWindowsService();
    }

    private void BindWindowsService()
    {
        Container
            .Bind<IWindowsService>()
            .To<WindowsService>()
            .AsSingle();
    }

    private void BindUIFactory()
    {
        Container
            .Bind<IUIFactory>()
            .To<UIFactory>()
            .AsSingle();
    }

    private void BindMeteoriteFactory()
    {
        Container
            .Bind<IMeteoriteFactory>()
            .To<MeteoriteFactory>()
            .AsSingle();
    }

    private void BindObjectPool()
    {
        Container
            .Bind<IObjectPool>()
            .To<ObjectPool>()
            .AsSingle();
    }

    private void BindGameFactory()
    {
        Container
            .Bind<IGameFactory>()
            .To<GameFactory>()
            .AsSingle()
            .NonLazy();
    }

    private void BindPlayerFactory()
    {
        Container
            .Bind<IPlayerFactory>()
            .To<PlayerFactory>()
            .AsSingle();
    }

    private void BindStaticDataService()
    {
        Container
            .Bind<IStaticDataService>()
            .To<StaticDataService>()
            .AsSingle()
            .NonLazy();
    }
}