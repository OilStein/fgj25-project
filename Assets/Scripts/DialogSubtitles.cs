using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSubtitles : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem;

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "";
        if (dialogSystem)
        {
            dialogSystem.EntryChange += OnEntryChange;
            dialogSystem.DialogStop += OnDialogStop;
        }
    }

    void OnDestroy()
    {
        if (dialogSystem)
        {
            dialogSystem.EntryChange -= OnEntryChange;
            dialogSystem.DialogStop -= OnDialogStop;
        }
    }

    private void OnDialogStop()
    {
        text.text = "";
    }

    private void OnEntryChange(DialogSeries.DialogEntry entry)
    {
        text.text = entry.SubtitleText;
    }
}
