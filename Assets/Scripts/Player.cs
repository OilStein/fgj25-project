using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;

    public float HealthDrainPerSecond = 1f;

    private float health;

    private bool isDead = false;

    private PlayerInput playerInput;

    public float Health => health;

    public event Action Death = delegate { };

    void Start()
    {
        health = maxHealth;
        playerInput = GetComponent<PlayerInput>();
        playerInput.Actions.Reload.performed += Reload;
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
        health -= HealthDrainPerSecond * Time.deltaTime;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Reload(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
