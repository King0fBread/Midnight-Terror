using UnityEngine;

public class PlayOneSoundByAnimationEvent : MonoBehaviour
{
    [SerializeField] private SoundsManager.Sounds _sound;
    public void PlaySoundViaManager()
    {
        SoundsManager.instance.PlaySound(_sound);
    }
}
