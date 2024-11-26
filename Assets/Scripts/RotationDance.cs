using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDance : MonoBehaviour
{
    public float speed = 5;
    public float sensitivity = 2;
    public float bias = 0.5f; // bias = base sensitivity

    void Start()
    {
        MusicPlayer.onBeat.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        transform.Rotate(0,0,bias + Mathf.Pow(volume,sensitivity) * speed);
    }
}
