using System;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Logic;
using CodeBase.Service.InputsService;
using CodeBase.UI.Service;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Gameplay.Player
{
    public class PlayerSetBomb : MonoBehaviour
    {
        public int MaxSpawnCountBombs { get; set; }
        
        public float TimerRespawnBomb = 10;
        
        public Transform SetBombPoint;

        private int _maxCountBombs;
        public float _timerRespawnBomb;
        
        private IInputService _inputService;
        private IObjectPool _objectPool;
        private IHudService _hudService;

        public void Construct(IObjectPool objectPool, IInputService inputService, IHudService hudService)
        {
            _hudService = hudService;
            _objectPool = objectPool;
            _inputService = inputService;
            _maxCountBombs = MaxSpawnCountBombs;
            _timerRespawnBomb = TimerRespawnBomb;
            _hudService.GetArmamentsCount(_maxCountBombs); ;
        }

     

        private void Update()
        {
            
            if (_inputService.GetLaserShooting)
            {
                if (_maxCountBombs != 0)
                {
                    _objectPool.ActiveObject(ArmamentsTypeId.Bomb, SetBombPoint.position);
                    --_maxCountBombs;
                    _hudService.GetArmamentsCount(_maxCountBombs);
                }
            }

            TimerRespawn();
        }


        private void TimerRespawn()
        {
            if (_maxCountBombs < MaxSpawnCountBombs)
            {
                _timerRespawnBomb -= Time.deltaTime;
                if (_timerRespawnBomb <= 0)
                {
                    ++_maxCountBombs;
                    _hudService.GetArmamentsCount(_maxCountBombs);
                    _timerRespawnBomb = TimerRespawnBomb;
                }
            }
        }
    }
}