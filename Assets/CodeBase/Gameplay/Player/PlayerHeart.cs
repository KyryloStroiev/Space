using System;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.UI;
using CodeBase.UI.Config;
using CodeBase.UI.Service;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Gameplay.Player
{
    public class PlayerHeart : MonoBehaviour
    {
        public GameObject HeartPrefab;
        
        public LayerMask LayerMask;

        public PlayerMove PlayerMove;

        private IWindowsService _windowsService;
        private IPhysicsService _physicsService;
        private IInstanceFactory _instanceFactory;

        public event Action DeathPlayer;

        public void Construct(IWindowsService windowsService, IPhysicsService physicsService, IInstanceFactory instanceFactory)
        {
            _instanceFactory = instanceFactory;
            _physicsService = physicsService;
            _windowsService = windowsService;
        }

        private void Update()
        {
            if (CollisionMeteorite() != null)
            {
                Death();
            }
        }


        private void Death()
        {
            PlayerMove.enabled = false;
            DeathPlayer?.Invoke();
            _instanceFactory.CleanUp();
            _windowsService.Open(WindowsTypeId.GameOverMenu);

        }
        
        private Collider2D CollisionMeteorite() => 
            _physicsService.BoxCastCollider(HeartPrefab.transform, LayerMask);
    }
}