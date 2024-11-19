using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput input;
    InputAction MoveAction;
    InputAction RunAction;
    InputAction JumpAction;
    private PlayerMovement playerMovement;
    private Animator anim = null;
    private SpriteRenderer sprite;
    private bool isJump = false;
    void Start()
    {
        //インスタンス化
        this.playerMovement = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        input = FindObjectOfType<PlayerInput>();
        MoveAction = input.actions["Move"];
        RunAction = input.actions["Dush"];
        JumpAction = input.actions["Jump"];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(JumpAction.IsPressed() && isJump == false){
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
         else if(MoveAction.ReadValue<float>() > 0 && playerMovement._isGrounded == true){
            if(RunAction.IsPressed()){
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }
            else{
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            sprite.flipX = false;
        }
        else if(MoveAction.ReadValue<float>() < 0 && playerMovement._isGrounded == true){
            if(RunAction.IsPressed()){
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
