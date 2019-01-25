using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioClip _runAudio;
    private static AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _runAudio = Resources.Load<AudioClip>("run");

        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlayAudio(string audio)
    {
        switch (audio)
        {
            case "run":
                _audioSource.PlayOneShot(_runAudio);
                break;
            default:
                break;
        }
    }
}
