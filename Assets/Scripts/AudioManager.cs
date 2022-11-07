using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public Text subtitleText;
    public SubtitleClass[] subtitleArray;

    private int index;
    private float timeLine;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SetVolume();
        SetMute();
    }

    public void Start()
    {
        index = 0;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(Time.time);
        }
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

    void StartDialogue()
    {
        StartCoroutine(Subtitle(0));
    }

    void NextLyrics(float time)
    {
        SubtitleClass nextSubtitle = subtitleArray[index];

        subtitleText.text = (nextSubtitle != null && nextSubtitle.duration >= time - subtitleArray[index + 1].time) ? nextSubtitle.lyrics : "";

        timeLine = subtitleArray[index].duration;

        float duration;

        if (nextSubtitle != null)
        {
            duration = nextSubtitle.time + nextSubtitle.duration - time;
        }
        else duration = 0.1f;

        StartCoroutine(Subtitle(duration));
        index++;
    }

    IEnumerator Subtitle(float time)
    {
        yield return new WaitForSeconds(time);
        NextLyrics(audioSource.time);
    }
}
