using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Slider sliderVolume;
    public Toggle toggleVolume;
    public float volumeMax;

    private void Awake()
    {
        GetValue();
    }

    void GetValue()
    {
        volumeMax = 1;
        sliderVolume.value = PlayerPrefs.GetFloat("volume", volumeMax = 1);
        toggleVolume.isOn = PlayerPrefs.GetFloat("mute", 0) == 1;
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("SPrincipal");
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", sliderVolume.value);
    }

    public void MuteVolume()
    {
        PlayerPrefs.SetFloat("mute", (toggleVolume.isOn ? 1 : 0));
    }
}