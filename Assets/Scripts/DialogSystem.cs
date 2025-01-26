using System;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    private static DialogSystem instance;

    public static DialogSystem Instance => instance;

    private AudioSource audioSource;

    private DialogSeries currentSeries;
    private int currentIndex = 0;

    public event Action<DialogSeries.DialogEntry> EntryChange = delegate { };
    public event Action DialogStop = delegate { };

    public void PlayDialog(DialogSeries dialogSeries)
    {
        currentSeries = dialogSeries;
        currentIndex = 0;

        SetDialogEntry(currentSeries.Entries[currentIndex]);
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateDialog();
    }

    private void UpdateDialog()
    {
        if (currentSeries != null)
        {
            if (!audioSource.isPlaying)
            {
                currentIndex++;
                if (currentIndex >= currentSeries.Entries.Length)
                {
                    currentSeries = null;
                    DialogStop();
                    return;
                }
                
                SetDialogEntry(currentSeries.Entries[currentIndex]);
            }
        }
    }

    private void SetDialogEntry(DialogSeries.DialogEntry entry)
    {
        audioSource.Stop();
        audioSource.clip = entry.AudioClip;
        audioSource.Play();

        EntryChange(entry);
    }
}
