using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public SpriteRenderer graphics;

    public bool isInvincible = false;
    public float HealthBarFlashDelay;

    public void SetMaxHealt(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
