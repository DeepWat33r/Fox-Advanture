using UnityEngine;
using UnityEngine.Audio;
using System;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;
        
        void Awake()
        {
            foreach (var s in sounds)
            {
               s.source = gameObject.AddComponent<AudioSource>();
               s.source.clip = s.clip;
               s.source.volume = s.volume;
               s.source.pitch = s.pitch;
               s.source.loop = s.loop;
               s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
            }
        }

        public void PlaySound(string name)
        {
            Sound s = Array.Find(sounds, sounds => sounds.name == name);
            if (s==null)
            {
                Debug.LogWarning("Sound: " + name + " not found");
                return;
            }
            s.source.Play();
        }
    }
}
