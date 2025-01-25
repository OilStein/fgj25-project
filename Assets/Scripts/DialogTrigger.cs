using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogSeries Dialog;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == GameConstants.Tags.Player)
        {
            DialogSystem.Instance.PlayDialog(Dialog);
        }
    }
}
