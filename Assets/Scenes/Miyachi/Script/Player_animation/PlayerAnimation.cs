using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim = null;
    private SpriteRenderer sprite;
    private bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        //インスタンス化
        this.playerMovement = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space)  && isJump == false){
            anim.SetTrigger("Jump");
            isJump = true;
        }
        else if(playerMovement._isGrounded == false && isJump == false){
            anim.SetTrigger("Fall");
            isJump = true;
        }
        else if(playerMovement._isGrounded == true && isJump == true){
            anim.SetTrigger("JumpEnd");
            isJump = false;
        }
         else if(Input.GetKey(KeyCode.RightArrow) && playerMovement._isGrounded == true){
            if(Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }
            else{
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            sprite.flipX = false;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && playerMovement._isGrounded == true){
            if(Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }
            else{
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            sprite.flipX = true;
            
        }
        else{
            anim.SetBool("Walk",false);
            anim.SetBool("Run",false);
        }
    }
}
