using CodeBase.Gameplay.Enemy;
using CodeBase.Infrastraction.States;
using CodeBase.UI.Config;
using CodeBase.UI.Service;
using UnityEngine;

namespace CodeBase.UI.Factory
{
    public interface IUIFactory
    {
        void Construct(IGameStateMachine gameStateMachine);
        GameObject CreateHud(SpawnMeteorite spawnMeteorite, IWindowsService windowsService);
        void CreateMenu(WindowsTypeId windowsTypeId);
        
    }
}