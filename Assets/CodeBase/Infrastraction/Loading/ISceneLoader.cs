using System;

namespace CodeBase.Infrastraction
{
    public interface ISceneLoader
    {
        void Load(string nameScene, Action onLoader = null);
    }
}