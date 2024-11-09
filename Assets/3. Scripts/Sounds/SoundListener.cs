using System;
using UnityEngine;
using UnityEngine.Events;

public class SoundListener : MonoBehaviour
{
    //private AudioSource audioSource;
    public SoundEventSO[] soSoundDatas;

    //public UnityAction action;
    [Serializable] public class SoundEvent : UnityEvent<SoundEventSO> { }
    public SoundEvent response;

    private void OnEnable()
    {
        foreach (var e in soSoundDatas)
            e.RegisterListener(this);
    }
    private void OnDisable()
    {
        foreach (var e in soSoundDatas)
            e.UnRegisterListener(this);
    }

    public void OnEventRaised(SoundEventSO soundEventSo)
    {
        response.Invoke(soundEventSo);
    }

    //public void SoundPlaySFX(SoundType type)
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    audioSource.PlayOneShot(soSoundDatas[(int)type].clip);
    //}
    //public void SoundPlayBGM(SoundType type)
    //{
    //    if (type != SoundType.BGM)
    //        return;

    //    audioSource = GetComponent<AudioSource>();
    //    var bgmClips = soSoundDatas[(int)type].clip;
    //    if (audioSource.clip != null)
    //        audioSource.Stop();

    //    audioSource.clip = bgmClips;
    //    audioSource.loop = true;
    //    audioSource.Play();
    //}
}