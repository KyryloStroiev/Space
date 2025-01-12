using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Gameplay.Armaments
{
    public class BombAnimation : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        private Material _material => SpriteRenderer.material;
        
        public float StartBlinkDuration = 0.5f;
        public float StartСountdownBlinkDuration = 0.2f;
        
        private Tween _blinkTween;


        private void OnEnable() => 
            StartBlinking(StartBlinkDuration);

        

        public void StopBlinking()
        {
            if (_blinkTween != null && _blinkTween.IsActive())
            {
                _blinkTween.Kill();
                _blinkTween = null;
            }
            
        }
        
        private void StartBlinking(float blinkDuration)
        {
            if (SpriteRenderer != null)
            {
                _blinkTween = _material.DOFade(1, blinkDuration)
                    .SetLoops(-1, LoopType.Yoyo) 
                    .From(0)           
                    .SetEase(Ease.Linear);       
            }
        }
        
        public void StartCountdownBlinking() => 
            StartBlinking(StartСountdownBlinkDuration);
    }
}