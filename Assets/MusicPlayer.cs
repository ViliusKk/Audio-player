using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public TMP_Text musicName;
    public TMP_Text currentTime;
    public TMP_Text musicLength;
    public Slider slider;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicName.text = audioSource.clip.name;
        int lengthInSeconds = Convert.ToInt32(audioSource.clip.length);
        //musicLength.text = $"{lengthInSeconds / 60}:{lengthInSeconds-(60* (lengthInSeconds / 60))}";
        int minutes = (int)audioSource.clip.length / 60;
        int seconds = (int)audioSource.clip.length % 60;
        musicLength.text = minutes + ':' + string.Format("{0:00}", seconds);

        slider.maxValue = lengthInSeconds;
    }

    void Update()
    {
        currentTime.text = $"{Convert.ToInt32(audioSource.time) / 60}:{Convert.ToInt32(audioSource.time) - (60 * (Convert.ToInt32(audioSource.time) / 60))}";
    }

    public void Pause()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }

    public void Next()
    {

    }

    public void Previous()
    {

    }

    public void SetTime(float time)
    {
        audioSource.time = time;
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}
