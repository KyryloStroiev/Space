using System;
using System.Collections;
using CodeBase.Infrastraction.Factory;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D Rigidbody;
        
        private float _speedBullet;
        private IObjectPool _objectPool;
        private float _durationDestroyBullet = 6f;

        public void Construct(IObjectPool objectPool)
        {
            _objectPool = objectPool;
        }
        public void StartShot(Vector3 direction, float speedBullet)
        {
            Rigidbody.velocity = direction * speedBullet;
            _durationDestroyBullet = 5f;
            StartCoroutine(ReturnToPool(_durationDestroyBullet));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            StartCoroutine(ReturnToPool(0.02f));
        }

        public IEnumerator ReturnToPool(float duration)
        {
            yield return new WaitForSeconds(duration);
            _objectPool.DisableObject(gameObject, AssetAdress.PlayerBullet);
        }
    }
}