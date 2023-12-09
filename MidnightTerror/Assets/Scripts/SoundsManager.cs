using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    private AudioClip _clip;
    public AudioClipPairedToSound[] audioClipsPairedToSounds;

    [System.Serializable]
    public class AudioClipPairedToSound
    {
        public AudioClip clip;
        public Sounds sound;
    }

    private static SoundsManager _instance;
    public static SoundsManager instance { get { return _instance; } }
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public enum Sounds
    {
        PlayerFootsteps1,
        PlayerFootsteps2,
        PlayerFootsteps3,
        ItemPickup,
        ItemUsedBoxcutter,
        ItemUsedCamera,
        ItemUsedKeyboxKey,
        ItemUsedKnife,
        ItemUsedRockOnToy,
        ItemUsedRope,
        ItemUsedShovel,
        UIButtonClick,
        AmbienceShack,
        AmbienceUnlitForest,
        AmbienceGraveyard,
        AmbienceSwamp
    }
    public void PlaySound(Sounds sound)
    {
        GetRequestedAudioClipByName(sound, out _clip);

        _source.PlayOneShot(_clip);
    }
    public void StopSound()
    {
        _source.Stop();
    }
    public void GetCurrentSound()
    {
        //return _source.clip;
    }
    public void PlayRandomWalkingSound()
    {
        int randomID = UnityEngine.Random.Range(0, 2);
        Array enumValues = Enum.GetValues(typeof(SoundsManager.Sounds));
        SoundsManager.Sounds sound = (SoundsManager.Sounds)enumValues.GetValue(randomID);

        PlaySound(sound);
    }
    private void GetRequestedAudioClipByName(Sounds soundToFind, out AudioClip _clip)
    {
        _clip = null;
        foreach(AudioClipPairedToSound audioClipPairedToSound in audioClipsPairedToSounds)
        {
            if(audioClipPairedToSound.sound == soundToFind)
            {
                _clip = audioClipPairedToSound.clip;
            }
        }
    }
}
