using UnityEngine;
using Zenject;

namespace CodeBase.Infrastraction
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain CurtainPrefab;

        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;


        private void Awake() 
        {
            var curtain = Instantiate(CurtainPrefab);
            _gameStateMachine.CreateAllState(new SceneLoader(this), curtain);
            _gameStateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}