using System.Collections.Generic;
using CodeBase.Infrastraction.Service;
using UnityEngine;
using Zenject;
using IPoolable = CodeBase.Gameplay.Logic.IPoolable;

namespace CodeBase.Gameplay.Factory
{
    public class InstanceFactory : IInstanceFactory
    {
        private readonly IStaticDataService _staticDataService;

        private List<GameObject> _allObjects;
        
        public InstanceFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _allObjects = new List<GameObject>(128);
        }
        
        public GameObject InstantiateObject(GameObject prefab)
        {
            GameObject gameObject = GameObject.Instantiate(prefab);
            _allObjects.Add(gameObject);
            return gameObject;
        }
        
        public GameObject InstantiateObject(GameObject prefab, Vector3 at)
        {
            GameObject gameObject = GameObject.Instantiate(prefab, at, Quaternion.identity);
            _allObjects.Add(gameObject);
            return gameObject;
        }

        public void CleanUp()
        {
            foreach (GameObject obj in _allObjects)
            {
                GameObject.Destroy(obj);
            }
            _allObjects?.Clear();
        }
    }
}