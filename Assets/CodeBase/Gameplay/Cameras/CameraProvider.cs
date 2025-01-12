
using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public class CameraProvider : ICameraProvider
    {
        public Camera MainCamera { get; private set; }
        
        public float WorldScreenHeight { get; private set; }
        public float WorldScreenWidth { get; private set; }

        public void SetMainCamera(Camera mainCamera)
        {
            MainCamera = mainCamera;
            
            RefreshBoundaries();
        }
        
        private void RefreshBoundaries()
        {
            Vector2 bottomLeft = MainCamera.ViewportToWorldPoint(new Vector3(0, 0, MainCamera.nearClipPlane));
            Vector2 topRight = MainCamera.ViewportToWorldPoint(new Vector3(1, 1, MainCamera.nearClipPlane));
            WorldScreenHeight = topRight.y - bottomLeft.y;
            WorldScreenWidth = (topRight.x - bottomLeft.x)*0.7f;
        }
    }
}