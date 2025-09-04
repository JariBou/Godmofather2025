using System;
using UnityEngine;

namespace _project.Scripts
{
    public class AudioManager :MonoBehaviour
    {
        public static AudioManager Instance;
        public Sound[] Sounds;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            foreach (var sound in Sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.loop = sound.loop;
            }
        }
        public void Play(string name)
        {
            Sound s = System.Array.Find(Sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
        }
        public void Stop(string name)
        {
            Sound s = System.Array.Find(Sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Stop();
        }
        
    }
}