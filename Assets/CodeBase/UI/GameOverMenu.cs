using CodeBase.Infrastraction.States;
using CodeBase.Infrastraction.States.GameStates;
using CodeBase.UI.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class GameOverMenu : MonoBehaviour
    {
        public Button StartGameButton;
        
        public TextMeshProUGUI YouScoreText;
       
        private IGameStateMachine _gameStateMachine;
        private IHudService _hudService;

        public void Construct(IGameStateMachine gameStateMachine, IHudService hudService)
        {
            _hudService = hudService;
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            StartGameButton.onClick.AddListener(StartGame);
            YouScoreText.text = $"Score: {_hudService.Score}";
        }

        private void StartGame()
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
            _gameStateMachine.Enter<LoadLevelState>();
        }

    }
}