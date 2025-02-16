using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPenemy : MonoBehaviour
{
    public Slider slider; //posuva hp
    public Gradient gradient; // farebny panel s hp
    public Image vnutro;
    public void SetmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        vnutro.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        vnutro.color = gradient.Evaluate(slider.normalizedValue);
    }
}
