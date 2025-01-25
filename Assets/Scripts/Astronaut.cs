using System;
using Unity.VisualScripting;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public float HealthAmount = 5;

    private bool healthPicked = false;

    private Player player;

    public bool HealthPicked => healthPicked;

    public void MarkPicked()
    {
        healthPicked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GameConstants.Tags.Player && !healthPicked)
        {
            player = other.gameObject.GetComponent<Player>();
            player.HealthPickTarget = this;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == GameConstants.Tags.Player && player)
        {
            player.HealthPickTarget = null;
        }
    }
}
