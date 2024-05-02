using CodeBase.Infrastraction;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject GameBootsrapperPrefab;
    public override void InstallBindings()
    {
        CreateGameBootstrapper();
        BindGameStateMachine();
    }

    private void BindGameStateMachine()
    {
        Container
            .Bind<IGameStateMachine>()
            .To<GameStateMachine>()
            .AsSingle();
    }

    private void CreateGameBootstrapper()
    {
        Container
            .Bind<GameBootstrapper>()
            .FromComponentInNewPrefab(GameBootsrapperPrefab)
            .AsSingle()
            .NonLazy();
    }
}