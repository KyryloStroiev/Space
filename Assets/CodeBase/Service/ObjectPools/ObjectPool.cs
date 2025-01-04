using System.Collections.Generic;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Player;
using CodeBase.Gameplay.Player.Factory;
using CodeBase.Infrastraction.Service;
using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public class ObjectPool : IObjectPool
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private Dictionary<ArmamentsTypeId, Queue<GameObject>> _objectQueue = new();

        private int _sizePool = 200;

        public ObjectPool(IArmamentsFactory armamentsFactory)
        {
            _armamentsFactory = armamentsFactory;
        }

        
        public void Instantiate()
        {
            CreateObject(ArmamentsTypeId.Bullet);
        }

        public GameObject ActiveObject(ArmamentsTypeId typeId, Vector3 position)
        {
            if (_objectQueue.ContainsKey(typeId))
            {
                GameObject obj = null;
                if (_objectQueue[typeId].Count > 0)
                {
                    obj = _objectQueue[typeId].Dequeue();
                }
                else
                {
                    obj = CreateObject(typeId);
                    _sizePool++;
                }

                obj.gameObject.transform.position = position;
                obj.gameObject.SetActive(true);
                return obj;
            }

            return null;
        }


        public void DisableObject(GameObject obj, ArmamentsTypeId typeId)
        {
            obj.gameObject.SetActive(false);
            _objectQueue[typeId].Enqueue(obj);
        }

        private GameObject CreateObject(ArmamentsTypeId typeId)
        {
            _objectQueue[typeId] = new Queue<GameObject>();
            
            for (int i = 0; i < _sizePool; i++)
            {
                GameObject obj = _armamentsFactory.CreateArmaments(typeId, this);
                obj.SetActive(false);
                _objectQueue[typeId].Enqueue(obj);
                return obj;
            }
            return null;
        }
    }
}