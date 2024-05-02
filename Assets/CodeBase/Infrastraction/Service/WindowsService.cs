using System;
using CodeBase.Infrastraction.Factory;
using CodeBase.StateData;
using Sirenix.OdinInspector;
using Zenject;

namespace CodeBase.Infrastraction.Service
{
    public class WindowsService : IWindowsService
    {
        private IUIFactory _uiFactory;
       

        [Inject]
        public WindowsService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            
        }

        public void CreateHud(SpawnMeteorite spawnMeteorite) => 
            _uiFactory.CreateHud(spawnMeteorite, this);

        public void Open(WindowsTypeId windowsTypeId)
        {
            switch (windowsTypeId)
            {
                case WindowsTypeId.Unknow:
                    break;
                case WindowsTypeId.StartMenu:
                    _uiFactory.CreateMenu(WindowsTypeId.StartMenu);
                    break;
                case WindowsTypeId.PauseMenu:
                    _uiFactory.CreateMenu(WindowsTypeId.PauseMenu);
                    break;
                case WindowsTypeId.GameOverMenu:
                    _uiFactory.CreateMenu(WindowsTypeId.GameOverMenu);
                    break;
               
            }
        }

        public void CleanUp()
        {
            _uiFactory.CleanUp();
        }
    }
}