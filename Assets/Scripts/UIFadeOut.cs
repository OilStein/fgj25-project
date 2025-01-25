using UnityEngine;
using UnityEngine.UI;

public class UIFadeOut : MonoBehaviour
{
    public AnimationCurve FadeAnimation = AnimationCurve.Linear(0, 0, 1, 1);

    [SerializeField]
    private Player player;

    private CanvasGroup canvasGroup;

    private bool fadingOut = false;
    private float timer;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        player.Death += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        fadingOut = true;
        timer = Time.time;
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