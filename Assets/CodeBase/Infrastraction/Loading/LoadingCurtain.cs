﻿using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastraction.Loading
{
    public class LoadingCurtain: MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1f;
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (Curtain.alpha > 0f)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
            gameObject.SetActive(false);
        }
    }
}