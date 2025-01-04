using CodeBase.Gameplay.Logic;
using UnityEngine;

namespace CodeBase.Gameplay.Factory
{
    public interface IInstanceFactory
    {
        GameObject InstantiateObject(GameObject prefab, Vector3 at);
        GameObject InstantiateObject(GameObject prefab);
        void CleanUp();
    }
}