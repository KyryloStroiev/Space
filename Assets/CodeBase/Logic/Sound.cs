using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Sound : MonoBehaviour
    {
        public AudioSource AudioSource;
        public SoundData SoundData;

        public void PlayOneShot(SoundType soundType)
        {
            AudioClip audioClip = SoundData.GetSound(soundType);

            if (soundType != null)
            {
                AudioSource.PlayOneShot(audioClip);
            }
        }

        public void PlayLoopSound(SoundType soundType)
        {
            AudioClip audioClip = SoundData.GetSound(soundType);

            if (audioClip != null)
            {
                AudioSource.clip = audioClip;
                AudioSource.loop = true;
                AudioSource.Play();
            }
        }
        
        public void SoundStop()
        {
            AudioSource.loop = false;
            AudioSource.Stop();
        }
    }
}