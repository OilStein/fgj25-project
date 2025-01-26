using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.gameObject.tag == GameConstants.Tags.Player)
        {
            triggered = true;
            GameWinState.Instance.EndGame();
        }
    }
}