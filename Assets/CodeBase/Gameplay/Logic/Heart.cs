using System;
using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public class Heart : MonoBehaviour
    {
        public event Action Hit;
        
        private void OnDestroy()
        {
            Hit?.Invoke();
        }
    }
}