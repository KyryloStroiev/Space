using UnityEngine;

namespace CodeBase.Common.PhysicsService
{
    public class PhysicsService : IPhysicsService
    {
         
        public Collider2D BoxCastCollider(Transform transform, int layerMask) => 
            Physics2D.OverlapBox(transform.position, transform.localScale, transform.eulerAngles.z, layerMask);
        
        
        public Collider2D CircleCastCollider(Vector3 position, float circleOffsetY, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(0, circleOffsetY);
        
            return Physics2D.OverlapCircle(playerCenter, circleRadius, layerMask);
        }

        public Collider2D[] CircleAllCastCollider(Vector3 position, float circleRadius, int layerMask)
        {
            
            return Physics2D.OverlapCircleAll(position, circleRadius, layerMask);
        }
    }
}