using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour
{
    private Animator anim = null;
    public AudioClip damageSound;
    AudioSource audioSource;

    void Start (){
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    //踏まれたときの処理
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "GroundCheck"){
            anim.SetTrigger("damage");
            audioSource.clip = damageSound;
            audioSource.volume = 0.3f;
            audioSource.Play();
        }
    }
}
