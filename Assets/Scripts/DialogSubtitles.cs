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
        dialogSystem.EntryChange += OnEntryChange;
        dialogSystem.DialogStop += OnDialogStop;
    }

    void OnDestroy()
    {
        dialogSystem.EntryChange -= OnEntryChange;
        dialogSystem.DialogStop -= OnDialogStop;
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
