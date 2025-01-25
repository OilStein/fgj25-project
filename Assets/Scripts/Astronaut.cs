using System;
using Unity.VisualScripting;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public float CurrentAir = 100;
    public float AirConsumptionRate = 5;

    bool isInZone = false;

    private Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger detected in astronaut with " + other.gameObject.name);
            player = other.gameObject.GetComponent<Player>();
            isInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited trigger zone: " + other.gameObject.name);
        isInZone = false;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInZone)
        {
            if (CurrentAir > 0)
            {
                CurrentAir -= AirConsumptionRate * Time.deltaTime;
                player.GainHealth(AirConsumptionRate * Time.deltaTime);
            }
            
        }
    }
}
