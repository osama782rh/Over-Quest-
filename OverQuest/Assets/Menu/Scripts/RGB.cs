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

    private void Start()
    {
        // Ajouter des écouteurs d'événements pour les sliders
        redSlider.onValueChanged.AddListener(UpdateBackgroundColor);
        greenSlider.onValueChanged.AddListener(UpdateBackgroundColor);
        blueSlider.onValueChanged.AddListener(UpdateBackgroundColor);
    }

    private void UpdateBackgroundColor(float value)
    {
        // Obtenir les valeurs des sliders
        float redValue = redSlider.value ;
        float greenValue = greenSlider.value ;
        float blueValue = blueSlider.value ;

        Debug.Log("r: " + redSlider.value + "g: " + greenSlider.value + "b: " + blueSlider.value);

        // Mettre à jour la couleur de l'arrière-plan
        Color newColor = new Color(redValue  , greenValue  , blueValue)  ;
        background.color = newColor;
    }
}