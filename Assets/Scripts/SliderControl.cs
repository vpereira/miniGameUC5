using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderControl : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    // Start is called before the first frame update

    public void SetHealth(float health, float maxHealth)
    {
        Debug.Log("Health:" + health + " maxHealth:" + maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
