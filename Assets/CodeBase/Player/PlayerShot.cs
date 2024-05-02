using System;
using CodeBase.Infrastraction.Factory;
using CodeBase.Logic;
using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerShot : MonoBehaviour
    {
        public Transform ShotPoint;
        public GameObject ShotCube;
     
        public float SpeedBullet { get; set; }
        public Sound Sound;

        [SerializeField] private float Cooldown;
        private float _attackCooldown;
        private bool _shooting;
        
        private IObjectPool _objectPool;
        private PlayerController _playerController;


        public void Construct(IObjectPool objectPool)
        {
            _objectPool = objectPool;
            _playerController = new PlayerController();
            _playerController?.Enable();
            _playerController.Player.Shot.started +=_=> StartShooting();
            _playerController.Player.Shot.canceled += _ => StopShooting();
            _attackCooldown = Cooldown;
        }

        private void Update()
        {
            UpdateCooldown();

            if (CooldownUp() && ShotCube != null && _shooting)
            {
                Shot();
            }
        }

        private void StartShooting()
        {
            Shot();
            _shooting = true;
        }

        private void StopShooting() => 
            _shooting = false;

        private void Shot()
        {
            if (CooldownUp() && ShotCube!= null)
            {
                GameObject bullet =  _objectPool.ActiveObject(AssetAdress.PlayerBullet, ShotPoint.position);
                Sound.PlayOneShot(SoundType.Shot);
                Bullet bullets = bullet.GetComponent<Bullet>();
                bullets.Construct(_objectPool);
                bullets.StartShot(Vector3.up, SpeedBullet);
                _attackCooldown = Cooldown;
            }
        }

        private void UpdateCooldown()
        {
            if (!CooldownUp())
            {
                _attackCooldown -= Time.deltaTime;
            }
        }
        
      
        
        private bool CooldownUp() => 
            _attackCooldown <= 0;
    
    }
}