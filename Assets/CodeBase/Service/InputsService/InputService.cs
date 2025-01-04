namespace CodeBase.Service.InputsService
{
    public class InputService : IInputService
    {
        private PlayerController _controller;
        private bool _getShootButtonPressed;

        public InputService()
        {
            _controller = new PlayerController();
            _controller?.Enable();
            
            _controller.Player.Shoot.performed +=_=> _getShootButtonPressed = true;
            _controller.Player.Shoot.canceled +=_=> _getShootButtonPressed = false;
            
        }

        public bool GetShooting => _getShootButtonPressed;
        
        public float Axis() => 
            _controller.Player.Move.ReadValue<float>();
    }
}