using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectedHealthBar : MonoBehaviour
{
    Slider slider;

    public Gradient gradient;

    Image fill;

    void Start() {
        slider = gameObject.GetComponent<Slider>();
        fill = gameObject.GetComponentInChildren<Image>();
    }


    public void SetEnemyMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnemyHealth(int health) {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
