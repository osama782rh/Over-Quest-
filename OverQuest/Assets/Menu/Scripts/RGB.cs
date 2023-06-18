using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGB : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Image background;
    public Image otherBackground;

    private const string RedKey = "RedValue";
    private const string GreenKey = "GreenValue";
    private const string BlueKey = "BlueValue";


    private void Start()
    {
        if (PlayerPrefs.HasKey(RedKey))
        {
            redSlider.value = PlayerPrefs.GetFloat(RedKey);
            greenSlider.value = PlayerPrefs.GetFloat(GreenKey);
            blueSlider.value = PlayerPrefs.GetFloat(BlueKey);
            UpdateBackgroundColor();
        }
        // Parametrage à partir des sliders
        redSlider.onValueChanged.AddListener(UpdateBackgroundColor);
        greenSlider.onValueChanged.AddListener(UpdateBackgroundColor);
        blueSlider.onValueChanged.AddListener(UpdateBackgroundColor);
    }

    private void UpdateBackgroundColor(float value)
    {
        // Sauvegarder les valeurs des sliders
        PlayerPrefs.SetFloat(RedKey, redSlider.value);
        PlayerPrefs.SetFloat(GreenKey, greenSlider.value);
        PlayerPrefs.SetFloat(BlueKey, blueSlider.value);
        PlayerPrefs.Save();

        // Mettre à jour la couleur de l'arrière-plan
        UpdateBackgroundColor();
    }

    private void UpdateBackgroundColor()
    {
        // Obtenir les valeurs des sliders
        float redValue = redSlider.value;
        float greenValue = greenSlider.value;
        float blueValue = blueSlider.value;

        // Mettre à jour la couleur de l'arrière-plan
        Color newColor = new Color(redValue, greenValue, blueValue);
        background.color = newColor;
    }

    private void UpdateOtherBackgroundColor()
    {
        float redValue = redSlider.value;
        float greenValue = greenSlider.value;
        float blueValue = blueSlider.value;

        Color newColor = new Color(redValue, greenValue, blueValue);
        otherBackground.color = newColor;
    }
}