using System;
using CodeBase.Infrastraction;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button StartGameButton;
    public Button CloseButton;

    private IGameStateMachine _gameStateMachine;

    public void Construct(IGameStateMachine gameStateMachine) => 
        _gameStateMachine = gameStateMachine;

    private void Start()
    {
        StartGameButton.onClick.AddListener(StartGame);
        if (CloseButton != null)
        {
            CloseButton.onClick.AddListener(BackGame);
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _gameStateMachine.Enter<LoadLevelState>();
    }

    private void BackGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
