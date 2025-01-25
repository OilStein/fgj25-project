using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;

    public float HealthDrainPerSecond = 1f;
    public float StandingHealthDrainPerSecond = 1f;

    public float DashDrain = 10f;

    private float health;

    private bool isDead = false;

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;

    public float Health => health;

    public event Action Death = delegate { };

    void Start()
    {
        health = maxHealth;
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();

        playerInput.Actions.Reload.performed += Reload;
        playerMovement.Dashed += OnDash;
    }

    void OnDestroy()
    {
        playerInput.Actions.Reload.performed -= Reload;
        playerMovement.Dashed -= OnDash;
    }

    public void GainLife(float heal)
    {
        if (isDead)
        {
            return;
        }

        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        Death();
    }

    void Update()
    {
        var movementSpeed = playerMovement.CurrentMovement.magnitude;
        var drain = movementSpeed <= 1f ? StandingHealthDrainPerSecond : HealthDrainPerSecond;
        DrainHealth(drain * Time.deltaTime);
    }

    private void DrainHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Reload(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDash()
    {
        DrainHealth(DashDrain);
    }
}
