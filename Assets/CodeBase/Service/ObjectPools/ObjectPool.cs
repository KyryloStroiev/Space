using System;
using System.Collections.Generic;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Player.Factory;
using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public class ObjectPool : IObjectPool
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private Dictionary<ArmamentsTypeId, Queue<GameObject>> _objectQueue = new();

      

        public ObjectPool(IArmamentsFactory armamentsFactory)
        {
            _armamentsFactory = armamentsFactory;
        }

        
        public void Instantiate()
        {
            CreateObject(ArmamentsTypeId.Bullet, 200);
            CreateObject(ArmamentsTypeId.Bomb, 3);
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
                    obj = CreateObject(typeId, 3);
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

        private GameObject CreateObject(ArmamentsTypeId typeId, float sizePool)
        {
            _objectQueue[typeId] = new Queue<GameObject>();

            GameObject lastObj = null;
            int z = 0;
            
            for (int i = 0; i < sizePool; i++)
            {
                
                GameObject obj = _armamentsFactory.CreateArmaments(typeId, this);
                obj.SetActive(false);
                _objectQueue[typeId].Enqueue(obj);
                lastObj = obj;
            }
            return lastObj;
        }
    }
}