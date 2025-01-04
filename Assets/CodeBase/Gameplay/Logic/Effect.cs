using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public class Effect : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2f);
        }
    }
}