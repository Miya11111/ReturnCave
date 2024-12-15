using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioClip stampSound;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StampSound(){
        audioSource.clip = stampSound;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
