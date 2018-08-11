using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.SoundManagerNamespace
{
    public class AudioManager : UnitySingleton<AudioManager>
    {

        public List<AudioSource> SoundAudioSources;
        public List<AudioSource> MusicAudioSources;
        
        void Start()
        {

            foreach (Transform child in GameObject.Find("SoundSources").gameObject.transform)
            {
                Debug.Log(child.GetComponent<AudioSource>());
                SoundAudioSources.Add(child.GetComponent<AudioSource>());
            }

            foreach (Transform child in GameObject.Find("MusicSources").gameObject.transform)
            {
                MusicAudioSources.Add(child.GetComponent<AudioSource>());
            }

        }
        

        public void PlaySound(string Clip)
        {
            foreach (AudioSource source in SoundAudioSources)
            {
                if (source.name == Clip)
                {
                    source.Play();
                    //source.PlayOneShotSoundManaged(source.clip);
                }
            }

        }

        public void PlayMusic(string Clip)
        {
            foreach (AudioSource source in MusicAudioSources)
            {
                if (source.name == Clip)
                {
                    source.PlayLoopingMusicManaged(1.0f, 2.0f, false);
                }
            }

        }

        public void StopMusic(string Clip)
        {
            foreach (AudioSource source in MusicAudioSources)
            {
                if (source.name == Clip)
                {
                    source.Stop();
                    source.StopLoopingMusicManaged();
                }
            }

        }

    }
}
