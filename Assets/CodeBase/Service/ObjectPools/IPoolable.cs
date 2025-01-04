using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public interface IPoolable
    {
         void Construct(IObjectPool objectPool);
         void OnSpawned();
         void OnReturnToPool();
         GameObject gameObject { get; set; }
    }
}