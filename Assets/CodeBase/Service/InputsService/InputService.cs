namespace CodeBase.Service.InputsService
{
    public class InputService : IInputService
    {
        private PlayerController _controller;
        private bool _getLaserShootButtonPressed;

        public InputService()
        {
            _controller = new PlayerController();
            _controller?.Enable();
            
            _controller.Player.Shoot.performed +=_=> _getLaserShootButtonPressed = true;
            _controller.Player.Shoot.canceled +=_=> _getLaserShootButtonPressed = false;
            
        }

        public bool GetLaserShooting => PressOnceButton();

        public float Axis() => 
            _controller.Player.Move.ReadValue<float>();

        private bool PressOnceButton()
        {
            if (_getLaserShootButtonPressed)
            {
                _getLaserShootButtonPressed = false;
                return true;
            }

            return false;
        }
    }
}