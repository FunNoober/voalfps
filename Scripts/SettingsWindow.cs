using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsWindow : MonoBehaviour
{
    public AudioMixer masterMixer;
    
    public void SetGraphicsLevel(int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void VolumeSetGame (float volume)
    {
        masterMixer.SetFloat("VolumeParam", volume);
    }

}
