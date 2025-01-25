using UnityEngine;

public class FootSfx : MonoBehaviour
{
    public float FootstepDistance = 1.5f;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private AudioClip[] footstepSounds;
    
    [SerializeField]
    private AudioClip jumpSound;
    
    [SerializeField]
    private AudioClip landSound;

    private AudioSource audioSource;

    private float distanceSinceLastFootstep;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement.Jumped += OnJump;
        playerMovement.Landed += OnLand;
    }

    void OnDestroy()
    {
        playerMovement.Jumped -= OnJump;
        playerMovement.Landed -= OnLand;
    }

    void Update()
    {
        var movement = playerMovement.CurrentMovement;
        if (playerMovement.IsGrounded && movement.magnitude > 1f)
        {
            if (distanceSinceLastFootstep >= FootstepDistance)
            {
                audioSource.Stop();
                audioSource.clip = PickClip(footstepSounds);
                audioSource.Play();
                distanceSinceLastFootstep = 0;
            }
            else
            {
                distanceSinceLastFootstep += movement.magnitude * Time.deltaTime;
            }
        }
    }

    private AudioClip PickClip(AudioClip[] clips)
    {
        int choice = Random.Range(0, clips.Length);
        return clips[choice];
    }

    private void OnJump()
    {
        audioSource.Stop();
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    private void OnLand()
    {
        audioSource.Stop();
        audioSource.clip = landSound;
        audioSource.Play();
    }
}
