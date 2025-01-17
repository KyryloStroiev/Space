using UnityEngine;

namespace CodeBase.Gameplay.Obstacle.Factory
{
    public interface IObstacleFactory
    {
        GameObject CreateUndestroyableBlock(ObstacleTypeId typeId );
    }
}