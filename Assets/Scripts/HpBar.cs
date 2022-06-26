using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHp(float hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHp(float hp)
    {
        slider.value = hp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
