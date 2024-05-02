using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastraction
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}