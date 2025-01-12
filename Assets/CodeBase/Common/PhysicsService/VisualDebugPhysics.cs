using UnityEngine;

namespace CodeBase.Common.PhysicsService
{
    public class VisualDebugPhysics : MonoBehaviour
    {
        public float CircleRadius;

        private void OnDrawGizmos()
        {
            
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(transform.position, CircleRadius);
        }
    }
}