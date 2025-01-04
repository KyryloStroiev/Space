using CodeBase.Gameplay.Logic;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Factory
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer(Vector3 at);
        
    }
}