using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderValueTest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.onValueChanged.AddListener(UpdateValue);
        UpdateValue(slider.value);
    }

    void UpdateValue(float value)
    {
        sliderValueTest.text = value.ToString();
    }
}
