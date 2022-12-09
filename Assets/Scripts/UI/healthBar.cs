using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    [SerializeField] Slider healthBarSlider;
    public void setHealth(float value)
    {
        healthBarSlider.value = value > 0 ? value : 0;
        fill.color = gradient.Evaluate(healthBarSlider.normalizedValue);
    }
}
