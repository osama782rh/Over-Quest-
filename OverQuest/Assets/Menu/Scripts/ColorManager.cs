using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static float redValue;
    public static float greenValue;
    public static float blueValue;

    private const string RedKey = "RedValue";
    private const string GreenKey = "GreenValue";
    private const string BlueKey = "BlueValue";

    private void Awake()
    {
        LoadColors();
    }

    private void OnApplicationQuit()
    {
        SaveColors();
    }

    private void SaveColors()
    {
        PlayerPrefs.SetFloat(RedKey, redValue);
        PlayerPrefs.SetFloat(GreenKey, greenValue);
        PlayerPrefs.SetFloat(BlueKey, blueValue);
        PlayerPrefs.Save();
    }

    private void LoadColors()
    {
        if (PlayerPrefs.HasKey(RedKey))
        {
            redValue = PlayerPrefs.GetFloat(RedKey);
            greenValue = PlayerPrefs.GetFloat(GreenKey);
            blueValue = PlayerPrefs.GetFloat(BlueKey);
        }
    }
}