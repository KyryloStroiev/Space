using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Logic;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Factory
{
    public interface IArmamentsFactory
    {
        GameObject CreateArmaments(ArmamentsTypeId typeId, IObjectPool objectPool);
    }
}