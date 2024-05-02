using System;
using CodeBase.Infrastraction.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Logic;
using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        public Heart Heart;
        public PlayerMove PlayerMove;
        private IWindowsService _windowsService;


        public event Action DeathPlayer;

        public void Construct(IWindowsService windowsService)
        {
            _windowsService = windowsService;
        }

        private void Start()
        {
            Heart.Hit += Death;
        }

        private void Death()
        {
            PlayerMove.enabled = false;
            DeathPlayer?.Invoke();
            
            _windowsService.Open(WindowsTypeId.GameOverMenu);

        }
    }
}