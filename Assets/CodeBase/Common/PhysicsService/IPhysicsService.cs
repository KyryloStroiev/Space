using UnityEngine;

namespace CodeBase.Common.PhysicsService
{
    public interface IPhysicsService
    {
        Collider2D CircleCastCollider(Vector3 position, float circleOffsetY, float circleRadius, int layerMask);
        Collider2D BoxCastCollider(Transform transform, int layerMask);
    }
}