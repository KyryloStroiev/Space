using System.Collections.Generic;
using CodeBase.Infrastraction.Factory;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class ObjectPool : IObjectPool
    {
        private Dictionary<string, Queue<GameObject>> _objectQueue = new();

        private int _sizePool = 40;
        private IGameFactory _gameFactory;


        [Inject]
        public ObjectPool(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Instantiate()
        {
            CreateObject(AssetAdress.PlayerBullet);
        }

        private void CreateObject(string pathPrefab)
        {
            _objectQueue[pathPrefab] = new Queue<GameObject>();

            for (int i = 0; i < _sizePool; i++)
            {
                GameObject obj = _gameFactory.InstantiateObject(pathPrefab);
                _objectQueue[pathPrefab].Enqueue(obj);
                obj.SetActive(false);
            }
        }

        public GameObject ActiveObject(string pathPrefab, Vector3 position)
        {
            if (_objectQueue.ContainsKey(pathPrefab))
            {
                GameObject obj = null;
                if (_objectQueue[pathPrefab].Count > 0)
                {
                    obj = _objectQueue[pathPrefab].Dequeue();
                }
                else
                {
                    obj = _gameFactory.InstantiateObject(pathPrefab);
                    _sizePool++;
                }

                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }

            return null;
        }

        public void DisableObject(GameObject obj, string pathPrefab)
        {
            obj.SetActive(false);
            _objectQueue[pathPrefab].Enqueue(obj);
        }
    }
}