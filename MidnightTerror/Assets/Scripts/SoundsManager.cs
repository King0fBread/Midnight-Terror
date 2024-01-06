using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _mainAudioSource;
    [SerializeField] private AudioSource _ambienceAudioSource;
    private bool _isCurrentSoundAmbience = false;

    private AudioClip _currentAmbienceSoundClip;

    public AudioClipPairedToSound[] audioClipsPairedToSounds;

    [System.Serializable]
    public class AudioClipPairedToSound
    {
        public AudioClip clip;
        public Sounds sound;
        public bool isAmbienceSound = false;
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
        GhostLaughUnlitForest,
        AmbienceGraveyard,
        AmbienceSwamp,
        MainGateGameStartLightning,
        GhostImpactForestFinal,
        GhostImpactUnlitForest,
        CoffinCutsceneSound,
        GhostImpactSmiling,
    }
    public void PlaySound(Sounds sound)
    {
        PlayClipInAppropriateAudioSource(GetRequestedAudioClipByName(sound), _isCurrentSoundAmbience);
    }
    public void StopSoundManually(bool isAmbientSound)
    {
        if (isAmbientSound)
        {
            _ambienceAudioSource.Stop();
        }
        else
        {
            _mainAudioSource.Stop();
        }
    }
    private void Update()
    {
        //looping the ambient sound if player is not moving
        if(!_ambienceAudioSource.isPlaying && _currentAmbienceSoundClip != null)
        {
            _ambienceAudioSource.PlayOneShot(_currentAmbienceSoundClip);
        }
    }
    public void PlayRandomWalkingSound()
    {
        int randomID = UnityEngine.Random.Range(0, 2);
        Array enumValues = Enum.GetValues(typeof(SoundsManager.Sounds));
        SoundsManager.Sounds sound = (SoundsManager.Sounds)enumValues.GetValue(randomID);

        PlaySound(sound);
    }
    private AudioClip GetRequestedAudioClipByName(Sounds soundToFind)
    {
        foreach(AudioClipPairedToSound audioClipPairedToSound in audioClipsPairedToSounds)
        {
            if(audioClipPairedToSound.sound == soundToFind)
            {
                _isCurrentSoundAmbience = audioClipPairedToSound.isAmbienceSound;
                return audioClipPairedToSound.clip;
            }
        }
        return null;
    }
    private void PlayClipInAppropriateAudioSource(AudioClip clip, bool isAmbientSound)
    {
        if (isAmbientSound)
        {
            _currentAmbienceSoundClip = clip;

            _ambienceAudioSource.Stop();
            _ambienceAudioSource.PlayOneShot(clip);
        }
        else
        {
            _mainAudioSource.PlayOneShot(clip);
        }
    }
    public bool IsRequredAmbiencePlaying(Sounds sound)
    {
        bool requiredSoundIsCurrentlyPlaying = _ambienceAudioSource.clip == GetRequestedAudioClipByName(sound) ? true : false;
        return requiredSoundIsCurrentlyPlaying; 
    }
}
