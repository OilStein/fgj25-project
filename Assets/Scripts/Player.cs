using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    void Start()
    {
        health = maxHealth;
    }

    public void LoseLife(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Player lost health: " + health);
    }

    public void GainLife(int heal)
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
}
