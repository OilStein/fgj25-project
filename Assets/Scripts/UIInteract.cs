using System;
using UnityEngine;

public class UIInteract : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        player.HealthPickTargetChange += OnPickTargetChange;
    }

    void OnDestroy()
    {
        player.HealthPickTargetChange -= OnPickTargetChange;
    }

    private void OnPickTargetChange(Astronaut astronaut)
    {
        if (astronaut == null)
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            canvasGroup.alpha = 1;
        }
    }
}