using UnityEngine;

namespace CodeBase.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        Vector3 StartPoint { get; }
        void SetStartPoint(Vector3 startpoint);
    }
}