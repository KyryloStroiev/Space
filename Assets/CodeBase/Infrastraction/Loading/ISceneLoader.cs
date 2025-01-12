using System;

namespace CodeBase.Infrastraction.Loading
{
    public interface ISceneLoader
    {
        void Load(string nameScene, Action onLoader = null);
    }
}