using CodeBase.Infrastraction.Service;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastraction.Factory
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer(Vector3 at, IObjectPool objectPool, IWindowsService windowsService);
        void CleanUp();

    }
}