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
        volumeMax = 100;
        sliderVolume.value = PlayerPrefs.GetFloat("volume", volumeMax);

        toggleVolume.isOn = GetBoolMute();
    }
    public void PlayScene()
    {
        SceneManager.LoadScene("SPrincipal");
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", sliderVolume.value);
    }

    public bool GetBoolMute()
    {
        if (PlayerPrefs.GetFloat("mute") == 1)
        {
            return true;
        }
        else return false;
    }

    public void MuteVolume()
    {
        PlayerPrefs.SetFloat("mute", (toggleVolume ? 1 : 0));
    }
}