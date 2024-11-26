using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public TMP_Text musicName;
    public TMP_Text currentTime;
    public TMP_Text musicLength;
    public Slider slider;
    public static UnityEvent<float> onBeat = new();
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicName.text = audioSource.clip.name;
        int lengthInSeconds = Convert.ToInt32(audioSource.clip.length);
        musicLength.text = $"{lengthInSeconds / 60}:{string.Format("{0:00}",lengthInSeconds % 60)}";  //my solution

        // teacher's solution
        //int minutes = (int)audioSource.clip.length / 60;
        //int seconds = (int)audioSource.clip.length % 60;
        //musicLength.text = minutes + ":" + string.Format("{0:00}", seconds);

        slider.maxValue = lengthInSeconds;
    }

    void Update()
    {
        currentTime.text = $"{Convert.ToInt32(audioSource.time) / 60}:{string.Format("{0:00}",Convert.ToInt32(audioSource.time) % 60)}";

        slider.value = audioSource.time;

        float[] samples = new float[512];
        audioSource.clip.GetData(samples, audioSource.timeSamples);

        float sum = 0;
        foreach (var sample in samples)
        {
            sum += Mathf.Abs(sample);
        }
        float average = sum / samples.Length;

        onBeat.Invoke(average);
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
