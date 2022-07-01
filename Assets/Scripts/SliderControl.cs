using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderControl : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;

    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
    }
}
