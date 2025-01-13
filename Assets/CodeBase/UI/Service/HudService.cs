using System;
using CodeBase.Gameplay.Armaments;

namespace CodeBase.UI.Service
{
    public class HudService : IHudService
    {
        public event Action<int> SetArmamentsCount;
        public event Action<int> SetScore;
        

        public void GetArmamentsCount( int armamentsCount)
        {
            SetArmamentsCount?.Invoke(armamentsCount);
        }

        public void GetScore(int score)
        {
            SetScore?.Invoke(score);
        }
        
    }
}