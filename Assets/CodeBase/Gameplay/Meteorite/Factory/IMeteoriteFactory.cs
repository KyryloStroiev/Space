using CodeBase.Gameplay.Enemy;
using UnityEngine;

namespace CodeBase.Gameplay.Factory
{
    public interface IMeteoriteFactory
    {
        GameObject CreateSpawn();
        GameObject CreateMeteorite(MeteoriteTypeId meteoriteTypeId);
    }
}