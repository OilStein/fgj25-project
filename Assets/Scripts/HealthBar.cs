using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;  // Reference to the UI slider
    public Gradient healthGradient;  // Gradient for the health color
    public Image fillImage;  // Reference to the fill image in the slider

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        UpdateFillColor();
    }

    public void SetHealth(int currentHealth)
    {
        healthSlider.value = currentHealth;
        UpdateFillColor();
    }

    private void UpdateFillColor()
    {
        if (fillImage != null && healthGradient != null)
        {
            fillImage.color = healthGradient.Evaluate(healthSlider.normalizedValue);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
