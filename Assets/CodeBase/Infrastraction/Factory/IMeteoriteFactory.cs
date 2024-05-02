using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Infrastraction.Factory
{
    public interface IMeteoriteFactory
    {
        GameObject CreateSpawn();
        GameObject CreateMeteorite(MeteoriteTypeId meteoriteTypeId);
        void CleanUp();
    }
}