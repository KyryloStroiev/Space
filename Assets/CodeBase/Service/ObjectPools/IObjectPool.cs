﻿using System;
using CodeBase.Gameplay.Armaments;
using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public interface IObjectPool
    {
        void Instantiate();
        GameObject ActiveObject(ArmamentsTypeId typeId, Vector3 position);
        void DisableObject(GameObject obj, ArmamentsTypeId typeId);
    }
}