using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    AudioSource audioSource;
    bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPlay = !isPlay;
        }
        if (audioSource.isPlaying && !isPlay)
        {
            audioSource.Stop();
        }
        if (audioSource.isPlaying && isPlay)
        {
            audioSource.Play();
        }
    }
}
