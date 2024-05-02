using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Effect : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2f);
        }
    }
}