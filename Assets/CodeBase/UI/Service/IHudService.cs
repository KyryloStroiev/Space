using System;
using CodeBase.Gameplay.Armaments;

namespace CodeBase.UI.Service
{
    public interface IHudService
    {
        event Action<int> SetArmamentsCount;
        float Score { get; set; }
        void GetArmamentsCount(int armamentsCount);
        event Action<int> SetScore;
        void GetScore(int score);
    }
}