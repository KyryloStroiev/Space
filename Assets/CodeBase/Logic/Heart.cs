﻿using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Heart : MonoBehaviour
    {
        public event Action Hit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Hit?.Invoke();
            gameObject.SetActive(false);
        }
        
    }
}