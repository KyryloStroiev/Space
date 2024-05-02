using CodeBase.Infrastraction.Service;
using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Infrastraction.Factory
{
    public interface IUIFactory
    {
        void Construct(IGameStateMachine gameStateMachine);
        GameObject CreateHud(SpawnMeteorite spawnMeteorite,
            IWindowsService windowsService);
        void CreateMenu(WindowsTypeId windowsTypeId);
        
        void CleanUp();
    }
}