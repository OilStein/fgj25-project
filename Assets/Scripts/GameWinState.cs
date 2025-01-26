using System;
using UnityEngine;

public class GameWinState : MonoBehaviour
{
    private static GameWinState instance;

    public static GameWinState Instance => instance;

    public int BadEndingThreshold = 2;

    public DialogSeries BadEndingDialog;
    public DialogSeries GoodEndingDialog;

    private int badEndingCounter = 0;

    private bool? ending = null;

    public event Action<bool> GameEnded = delegate { };
    
    public void IncrementBadEndingCount()
    {
        badEndingCounter++;
    }

    public void EndGame()
    {
        ending = badEndingCounter >= BadEndingThreshold;
        var dialog = ending.Value ? BadEndingDialog : GoodEndingDialog;
        DialogSystem.Instance.PlayDialog(dialog);
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DialogSystem.Instance.DialogStop += OnDialogStop;
    }

    void OnDestroy()
    {
        DialogSystem.Instance.DialogStop -= OnDialogStop;
    }

    private void OnDialogStop()
    {
        if (!ending.HasValue)
        {
            return;
        }

        GameEnded(ending.Value);
    }
}