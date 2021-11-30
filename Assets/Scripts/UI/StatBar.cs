using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] TextMeshProUGUI amountText;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponentInChildren<Slider>();

        amountText = slider.GetComponentInChildren<TextMeshProUGUI>();

        slider.maxValue = 10;
    }

    public void SetValue(float value)
    {
        slider.value = value;
        //amountText.text = $"{value}/{slider.maxValue}";
        amountText.text = string.Format("{0:F1}/{1}", value, slider.maxValue);
    }

    public void Hide()
    {
        amountText.text = "";
        slider.value = 0;
    }

    
}
