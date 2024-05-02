using System;
using CodeBase.Logic;
using CodeBase.StateData;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject ParticleEffect;
    public Sound Sound;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        IHealth health = gameObject.GetComponentInParent<IHealth>();

        if (health != null)
        {
            health.TakeDamage(gameObject);
        }
        
        Sound.PlayOneShot(SoundType.PlayerHit);
        Instantiate(ParticleEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(other.gameObject, 0.2f);
    }
}