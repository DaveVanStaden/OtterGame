using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float SetMaxScore = 40;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetScore(string MaximalScore)
    {
        SetMaxScore = float.Parse(MaximalScore);
        print(SetMaxScore);
        StaticVariable.MaxScore = SetMaxScore;
    }
}
