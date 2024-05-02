using System;
using CodeBase.StateData;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Static Data/Sound")]
public class SoundData : ScriptableObject
{
    public AudioClip PlayerShot;
    public AudioClip PlayerHit;
    public AudioClip MeteoriteDamage;
    
    public AudioClip GetSound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Shot:
                return PlayerShot;
            case SoundType.PlayerHit:
                return PlayerHit;
            case SoundType.MeteoriteDamage:
                return MeteoriteDamage;
            default:
                throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
        }
    }
}
