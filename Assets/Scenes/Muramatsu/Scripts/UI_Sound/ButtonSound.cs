using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        // Œˆ’è‰¹‚ð–Â‚ç‚·
        audioSource.clip = sound;
        audioSource.volume = 0.25f;
        audioSource.Play();

        return;
    }
}
