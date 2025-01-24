using UnityEngine;

public class Player
{
    int health = 100;

    public void LoseLife(int damage)
    {
        health -= damage;
        Debug.Log("Player lost health: " + health);
    }

    public void GainLife(int heal)
    {
        health += heal;
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
