using UnityEngine;

public class Cylinder : MonoBehaviour
{

    public float lifeGain = 1.0f;

    private Player player;


    private bool isInTheZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger detected with " + other.gameObject.name);
            player = other.gameObject.GetComponent<Player>();
            isInTheZone = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited trigger zone: " + other.gameObject.name);
        isInTheZone = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTheZone)
        {
            player.GainLife(lifeGain * Time.deltaTime);
        }
    }
}
