using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSound : MonoBehaviour
{

    public AudioClip sound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnJumpSound(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}
