using UnityEngine;

namespace CodeBase.Infrastraction.Factory
{
    public interface IGameFactory
    {
        GameObject InstantiateObject(Vector3 at, string pathPrefab);
        GameObject InstantiateObject(string pathPrefab);
        void CleanUp();
    }
}