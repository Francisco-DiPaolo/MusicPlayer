using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Slider sliderVolume;
    public float volumeMax;

    private void Start()
    {
        volumeMax = 100;
        sliderVolume.value = PlayerPrefs.GetFloat("volume", volumeMax);
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

    }
}