using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingCube : MonoBehaviour
{
    public float sensitivity = 5;

    void Start()
    {
        MusicPlayer.onBeat.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        //transform.localScale = Vector3.one * volume * sensitivity; // changes xyz
        transform.localScale = new Vector3(1, 1 * volume * sensitivity, 1 * volume * sensitivity); // changes yz
        //transform.localScale = new Vector3(1, 1 * volume * sensitivity, 1); // changes y
    }
}