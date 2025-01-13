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
        
        private float _startBlinkDuration = 0.5f;
        
        private Tween _blinkTween;


        private void OnEnable() => 
            StartBlinking(_startBlinkDuration);

        
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
        
    }
}