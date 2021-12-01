using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public Sound[] sounds;

    [SerializeField] private AudioSource _musicSource, _effectsSource;
    
    void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        Debug.Log($"Play sound {s.name}");
        s.source.Play();
    }

    public IEnumerator FadeMusicOut(float fadeTime)
    {
        float startVolume = _musicSource.volume;

        while (_musicSource.volume > 0) {
            _musicSource.volume -= startVolume * Time.deltaTime / fadeTime;
 
            yield return null;
        }

        _musicSource.Stop ();
        _musicSource.volume = startVolume;
    }
}
