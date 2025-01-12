using System;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Logic;
using CodeBase.Service.InputsService;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    public class PlayerSetBomb : MonoBehaviour
    {
        public Transform SetBombPoint;
        
        private IInputService _inputService;
        private IObjectPool _objectPool;

        public void Construct(IObjectPool objectPool, IInputService inputService)
        {
            _objectPool = objectPool;
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.GetLaserShooting)
            {
                _objectPool.ActiveObject(ArmamentsTypeId.Bomb, SetBombPoint.position);
            }
        }
    }
}