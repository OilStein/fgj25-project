using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeOut : MonoBehaviour
{
    public AnimationCurve FadeAnimation = AnimationCurve.Linear(0, 0, 1, 1);

    public string DeathText = "You ded";
    public string WinText = "And so you and the AI lived happily ever after";

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Player player;

    private CanvasGroup canvasGroup;

    private bool fadingOut = false;
    private float timer;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        player.Death += OnPlayerDeath;
        GameWinState.Instance.GameEnded += OnGameEnded;
    }

    private void OnPlayerDeath()
    {
        fadingOut = true;
        timer = Time.time;
        text.text = DeathText;
    }

    private void OnGameEnded(bool badEnding)
    {
        fadingOut = true;
        timer = Time.time;
        text.text = badEnding ? DeathText : WinText;
    }

    void Update()
    {
        if (!fadingOut)
        {
            canvasGroup.alpha = 0;
            return;
        }

        float time = Time.time - timer;
        float alpha = FadeAnimation.Evaluate(time);
        canvasGroup.alpha = alpha;
    }
}