using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public float lifeGain = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GameConstants.Tags.Player)
        {
            Debug.Log("Trigger detected with " + other.gameObject.name);
            var player = other.gameObject.GetComponent<Player>();
            player.StartHealthGain(lifeGain);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited trigger zone: " + other.gameObject.name);
        if (other.gameObject.tag == GameConstants.Tags.Player)
        {
            Debug.Log("Trigger detected with " + other.gameObject.name);
            var player = other.gameObject.GetComponent<Player>();
            player.StopHealthGain();
        }
    }
}
