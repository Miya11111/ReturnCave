using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSound : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public AudioClip sound;
    AudioSource audioSource;

    private void Start()
    {
        this.playerMovement = FindObjectOfType<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnJumpSound(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && playerMovement._isGrounded == true)
        {
            audioSource.clip = sound;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }
    }
}
