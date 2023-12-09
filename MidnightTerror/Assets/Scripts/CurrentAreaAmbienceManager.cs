using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAreaAmbienceManager : MonoBehaviour
{
    [SerializeField] private List<AreaToSoundConnection> areasAmbientSounds;
    [Serializable]
    private struct AreaToSoundConnection
    {
        public int verticalCode;
        public int horizontalCode;
        public SoundsManager.Sounds sound;
    }
    public void GetCurentAreaCode(int verticalCode, int horizontalCode)
    {
        foreach(AreaToSoundConnection areaToSound in areasAmbientSounds)
        {

        }
    }
}
