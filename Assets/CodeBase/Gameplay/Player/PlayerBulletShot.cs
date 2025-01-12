using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Sounds;
using CodeBase.Infrastraction.Service;
using CodeBase.Service.InputsService;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    public class PlayerBulletShot : MonoBehaviour
    {
        public Transform ShotPoint;
        public GameObject ShotCube;

        public Sound Sound;

        public float SpeedBullet { get; set; }

        [SerializeField] private float Cooldown;
        private float _attackCooldown;

        private IObjectPool _objectPool;


        public void Construct(IObjectPool objectPool)
        {
            _objectPool = objectPool;
            _attackCooldown = Cooldown;
        }

        private void FixedUpdate()
        {
            UpdateCooldown();
            Shot();
        }


        private void Shot()
        {
            if (CooldownUp() && ShotCube!= null)
            {
                GameObject bullets =  _objectPool.ActiveObject(ArmamentsTypeId.Bullet, ShotPoint.position);
                Sound.PlayOneShot(SoundType.Shot);
                Bullet bullet = bullets.GetComponent<Bullet>();
                bullet.OnSpawned();
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