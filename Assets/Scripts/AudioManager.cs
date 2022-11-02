using UnityEngine;

public class AudioManager : MonoBehaviour
{
   AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SetVolume();
        SetMute();
    }

    void SetVolume()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        Debug.Log(audioSource.volume);
    }

    void SetMute()
    {
        audioSource.volume = PlayerPrefs.GetFloat("mute");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetVolume();
        }
    }
}
