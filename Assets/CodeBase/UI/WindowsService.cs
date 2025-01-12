using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Factory;

namespace CodeBase.UI
{
    public class WindowsService : IWindowsService
    {
        private IUIFactory _uiFactory;
        private readonly IInstanceFactory _instanceFactory;

        public WindowsService(IUIFactory uiFactory, IInstanceFactory instanceFactory)
        {
            _uiFactory = uiFactory;
            _instanceFactory = instanceFactory;
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
            //_instanceFactory.CleanUp();
        }
    }
    
}