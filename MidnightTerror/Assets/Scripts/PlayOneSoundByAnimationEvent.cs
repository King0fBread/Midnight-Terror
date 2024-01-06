using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneSoundByAnimationEvent : MonoBehaviour
{
    [SerializeField] private SoundsManager.Sounds _sound;
    public void PlaySoundViaManager()
    {
        SoundsManager.instance.PlaySound(_sound);
    }
}
