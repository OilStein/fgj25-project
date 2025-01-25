using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;

    public float HealthDrainPerSecond = 1f;

    private float health;

    public float Health => health;

    void Start()
    {
        health = maxHealth;
    }

    public void GainLife(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Player gained health: " + health);
    }

    public void Die()
    {
        Debug.Log("Player has died");
    }

    public void Respawn()
    {
        health = 100;
        Debug.Log("Player has respawned");
    }

    void Update()
    {
        health -= HealthDrainPerSecond * Time.deltaTime;
        if (health <= 0)
        {
            Die();
        }
    }
}
