using System;
using UnityEngine;

public class AudioMuffle : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private AudioLowPassFilter filter;

    void Start()
    {
        filter = GetComponent<AudioLowPassFilter>();
        filter.enabled = true;

        player.HealthGainStarted += StartHealthGain;
        player.HealthGainStopped += StopHealthGain;
    }

    void OnDestroy()
    {
        player.HealthGainStarted -= StartHealthGain;
        player.HealthGainStopped -= StopHealthGain;
    }

    private void StartHealthGain(float amount)
    {
        filter.enabled = false;
    }

    private void StopHealthGain()
    {
        filter.enabled = true;
    }
}