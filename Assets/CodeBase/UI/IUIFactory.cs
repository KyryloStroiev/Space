using CodeBase.Gameplay.Enemy;
using CodeBase.Infrastraction;
using CodeBase.Infrastraction.Service;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Factory
{
    public interface IUIFactory
    {
        void Construct(IGameStateMachine gameStateMachine);
        GameObject CreateHud(SpawnMeteorite spawnMeteorite, IWindowsService windowsService);
        void CreateMenu(WindowsTypeId windowsTypeId);
        
    }
}