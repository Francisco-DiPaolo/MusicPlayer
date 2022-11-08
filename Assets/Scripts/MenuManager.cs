using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider sliderVolume;
    public Toggle toggleMute;

    private void Awake()
    {
        GetValue();
    }

    void GetValue()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("volume", 1);
        toggleMute.isOn = PlayerPrefs.GetFloat("mute", 0) == 1;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", sliderVolume.value);
    }

    public void MuteVolume()
    {
        PlayerPrefs.SetFloat("mute", (toggleMute.isOn ? 1 : 0));
    }

    public void SetDefaultValues()
    {
        sliderVolume.value = 1;
        toggleMute.isOn = false;
    }

    public void ResetMusic()
    {
        PlayerPrefs.SetFloat("MusicTime", 0);
    }

    public void PlayScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}