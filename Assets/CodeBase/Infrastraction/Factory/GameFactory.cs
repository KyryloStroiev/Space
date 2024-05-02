using System.Collections.Generic;
using CodeBase.Infrastraction.Service;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastraction.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;

        private List<GameObject> _allObjects;

        [Inject]
        public GameFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _allObjects = new List<GameObject>();
        }
        
        public GameObject InstantiateObject(Vector3 at, string pathPrefab)
        {
            GameObject prefab = Resources.Load<GameObject>(pathPrefab);
            GameObject gameObject = GameObject.Instantiate(prefab, at, Quaternion.identity);
            _allObjects.Add(gameObject);
            return gameObject;
        }

        public GameObject InstantiateObject(string pathPrefab)
        {
            GameObject prefab = Resources.Load<GameObject>(pathPrefab);
            GameObject gameObject = GameObject.Instantiate(prefab);
            _allObjects.Add(gameObject);
            return gameObject;
        }

        public GameObject InstantiateObject(GameObject prefab)
        {
            GameObject gameObject = GameObject.Instantiate(prefab);
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