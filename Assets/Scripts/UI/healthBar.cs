using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    public Slider healthBarSlider;
    public void setHealth(float value)
    {
        value = Mathf.Clamp(value, 0, 100);
        healthBarSlider.value = value;
        fill.color = gradient.Evaluate(healthBarSlider.normalizedValue);
    }
}
