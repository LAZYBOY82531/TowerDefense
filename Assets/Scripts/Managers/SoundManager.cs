using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSourceEffect;
    AudioSource audioSourceBGM;
    public enum Sound { Bgm, Effect, UIS }

    private void Awake()
    {
        audioSourceEffect = GameManager.Resource.Instantiate<AudioSource>("Sound/AudioSource");
        audioSourceBGM = GameManager.Resource.Instantiate<AudioSource>("Sound/AudioSource");
        audioSourceBGM.name = "AudioSourceBGM";
        audioSourceEffect.name = "AudioSourceEffect";
        audioSourceBGM.outputAudioMixerGroup = GameManager.Resource.Load<AudioMixerGroup>("Sound/BGM");
        audioSourceEffect.outputAudioMixerGroup = GameManager.Resource.Load<AudioMixerGroup>("Sound/SFX(GameAudio)");
    }

    public void Play(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Sound.Bgm)
        {
            if (!audioSourceBGM.isPlaying)
            {
                audioSourceBGM.transform.parent = Camera.main.transform;
                audioSourceBGM.pitch = pitch;
                audioSourceBGM.clip = audioClip;
                audioSourceBGM.loop = true;
                audioSourceBGM.Play();
            }
            else
            {
                audioSourceBGM.Stop();
                audioSourceBGM.pitch = pitch;
                audioSourceBGM.clip = audioClip;
                audioSourceBGM.loop = true;
                audioSourceBGM.Play();
            }

        }
        else if (type == Sound.Effect)
        {
            audioSourceEffect.transform.parent = Camera.main.transform;
            audioSourceEffect.pitch = pitch;
            audioSourceEffect.PlayOneShot(audioClip);
        }
        else
        {

        }
    }

    public void Play(string path, UnityEngine.Transform transform, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GameManager.Resource.Load<AudioClip>(path);
        StartCoroutine(PlayEffectRoutine(audioClip, transform, type, pitch));
    }

    public void Play(string path, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GameManager.Resource.Load<AudioClip>(path);
        Play(audioClip, type, pitch);
    }

    IEnumerator PlayEffectRoutine(AudioClip audioClip, UnityEngine.Transform transform, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        while (true)
        {
            AudioSource audioSource = GameManager.Pool.Get(GameManager.Resource.Load<AudioSource>("Sound/AudioSource"), transform.position, transform.rotation);
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
            yield return new WaitForSeconds(3f);
            GameManager.Pool.Release(audioSource);
            yield break;
        }
    }
}
