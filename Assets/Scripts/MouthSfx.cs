using System;
using UnityEngine;

public class MouthSfx : MonoBehaviour
{
    [SerializeField]
    private AudioClip jumpSound;
    
    [SerializeField]
    private AudioClip airSound;
    
    [SerializeField]
    private Player player;
    
    [SerializeField]
    private PlayerMovement playerMovement;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player.HealthGainStarted += OnHealthGainStarted;
        player.Death += OnDeath;
        playerMovement.Jumped += OnJump;
        playerMovement.Dashed += OnDash;
    }

    void OnDestroy()
    {
        player.HealthGainStarted -= OnHealthGainStarted;
        player.Death -= OnDeath;
        playerMovement.Jumped -= OnJump;
        playerMovement.Dashed -= OnDash;
    }

    private void OnHealthGainStarted(float amountPerSecond)
    {
        Play(airSound);
    }

    private void OnDeath()
    {
        Play(airSound);
    }

    private void OnJump()
    {
        Play(jumpSound);
    }

    private void OnDash()
    {
        Play(airSound);
    }

    private void Play(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}