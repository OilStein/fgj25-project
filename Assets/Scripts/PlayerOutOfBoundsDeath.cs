using UnityEngine;

public class PlayerOutOfBoundsDeath : MonoBehaviour
{
    public Vector3 Origin;
    public float MaxDistanceFromOrigin = 500f;

    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Origin) >= MaxDistanceFromOrigin)
        {
            player.Die();
        }
    }
}
