using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Text subtitleText;
    public SubtitleClass[] subtitleArray;
    public float saveTime;

    private int _index;
    private float _duration;

    private void Awake()
    {
        SetVolume();
        SetMute();
        SetMusicTime();

        audioSource.Play();
    }

    public void Start()
    {
        _index = 0;
        StartCoroutine(Subtitle(0));
        InvokeRepeating("PlaySoundSpecificTime", 0, saveTime);
    }

    void SetVolume()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }

    void SetMute()
    {
        if (PlayerPrefs.GetFloat("mute") == 1)
        {
            audioSource.mute = true;
        }
        else audioSource.mute = false;
    }

    void SetMusicTime()
    {
        audioSource.time = PlayerPrefs.GetFloat("MusicTime", 0);
    }

    public void PlaySoundSpecificTime()
    {
        PlayerPrefs.SetFloat("MusicTime", audioSource.time);
    }

    void NextLyrics(float time)
    {
        SubtitleClass subtitle = subtitleArray[_index];
        SubtitleClass nextSubtitle = subtitleArray[_index + 1];

        if (subtitle != null)
        {
            if (nextSubtitle.latest)
            {
                _duration = audioSource.clip.length - audioSource.time;
                _index = 0;
            }
            else _duration = nextSubtitle.time - audioSource.time;

            subtitleText.text = subtitle.lyrics;
        }

        if (!nextSubtitle.latest)
        {
            _index++;
        }

        StartCoroutine(Subtitle(_duration));
    }

    IEnumerator Subtitle(float time)
    {
        yield return new WaitForSeconds(time);
        NextLyrics(audioSource.time);
    }

    public void ReturnScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}