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
            GameObject bulletPrefab = _instanceFactory.InstantiateObject(_staticDataService.ForPlayer().BulletPrefab);
            Bullet bullet = bulletPrefab.GetComponent<Bullet>();
            bullet.Construct(objectPool, _physicsService);
            bullet.SpeedBullet = _staticDataService.ForPlayer().SpeedBullet;
            
            return bulletPrefab;
        }

        private GameObject CreateBomb(IObjectPool objectPool)
        {
            GameObject bombPrefab = _instanceFactory.InstantiateObject(_staticDataService.ForPlayer().BombPrefab);
            Bomb bomb = bombPrefab.GetComponent<Bomb>();
            bomb.Construct(objectPool, _physicsService);

            return bombPrefab;
        }
    
        
    }
}