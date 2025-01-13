using System;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.Infrastraction.Service;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Factory
{
    public class ArmamentsFactory : IArmamentsFactory
    {
        private readonly IInstanceFactory _instanceFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IPhysicsService _physicsService;

        public ArmamentsFactory(IInstanceFactory instanceFactory, IStaticDataService staticDataService, IPhysicsService physicsService)
        {
            _instanceFactory = instanceFactory;
            _staticDataService = staticDataService;
            _physicsService = physicsService;
        }


        public GameObject CreateArmaments(ArmamentsTypeId typeId, IObjectPool objectPool)
        {
            switch (typeId)
            {
                case ArmamentsTypeId.Bullet:
                  return  CreateBullet(objectPool);

                case ArmamentsTypeId.Bomb:
                    return CreateBomb(objectPool);
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeId), typeId, null);
            }
        }
        
        
        private GameObject CreateBullet(IObjectPool objectPool)
        {
            ArmamentData armamentData = _staticDataService.GetArmamentData(ArmamentsTypeId.Bullet, 1);
            
            GameObject bulletPrefab = _instanceFactory.InstantiateObject(armamentData.Prefab);
            Bullet bullet = bulletPrefab.GetComponent<Bullet>();
            bullet.Construct(objectPool, _physicsService);
            bullet.SpeedBullet = armamentData.Speed;
            bullet.CircleRadius = armamentData.CircleRadius;
            
            return bulletPrefab;
        }

        private GameObject CreateBomb(IObjectPool objectPool)
        {
            ArmamentData armamentData = _staticDataService.GetArmamentData(ArmamentsTypeId.Bomb, 1);
            
            GameObject bombPrefab = _instanceFactory.InstantiateObject(armamentData.Prefab);
            Bomb bomb = bombPrefab.GetComponent<Bomb>();
            bomb.Construct(objectPool, _physicsService);
            bomb.TimeToExplode = armamentData.TimeToExplode;
            bomb.CircleRadius = armamentData.CircleRadius;

            return bombPrefab;
        }
    
        
    }
}