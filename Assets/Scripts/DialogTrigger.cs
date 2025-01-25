using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogSeries Dialog;

    private bool triggered = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!triggered && collider.gameObject.tag == GameConstants.Tags.Player)
        {
            DialogSystem.Instance.PlayDialog(Dialog);
            triggered = true;
        }
    }
}
