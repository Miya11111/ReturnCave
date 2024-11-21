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
        // Debug.Log("JUMPACTION: " + JumpAction.IsPressed() + "ISJUMP:" + isJump);
        anim.speed = 1;
        //優先順位が高いものから順に並べる
        //登る
        if(playerMovement._isClimb_anim == true){
            anim.SetBool("Climb", true);
            anim.SetBool("Walk",false);
            anim.SetBool("Run",false);
            if(playerMovement._isClimb_stop_anim){
                anim.speed = 0;
            }
        }
        //右に動く
         else if(MoveAction.ReadValue<float>() > 0 && playerMovement._isGrounded == true){
            if(RunAction.IsPressed()){
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Climb", false);
            }
            else{
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                anim.SetBool("Climb", false);
            }
            sprite.flipX = false;
        }
        //左に動く
        else if(MoveAction.ReadValue<float>() < 0 && playerMovement._isGrounded == true){
            if(RunAction.IsPressed()){
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Climb", false);
            }
            else{
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                anim.SetBool("Climb", false);
            }
            sprite.flipX = true;
            
        }
        //なにもしない
        else{
            anim.SetBool("Walk",false);
            anim.SetBool("Run",false);
            anim.SetBool("Climb",false);
            anim.ResetTrigger("JumpEnd");
        }

        //ジャンプ終了
        if(playerMovement._isGrounded == true && isJump == true){
            anim.SetTrigger("JumpEnd");
            isJump = false;
        }
        //ジャンプ
        if(JumpAction.IsPressed() && isJump == false){
            anim.SetTrigger("Jump");
            isJump = true;
        }
        //落ちる
        if(playerMovement._isGrounded == false && isJump == false){
            anim.SetTrigger("Fall");
            isJump = true;
        }
        //バグ回避のため
        if(playerMovement._isGrounded == true && anim.GetNextAnimatorStateInfo(0).IsName("Main_Character_jump")){
            anim.SetTrigger("JumpEnd");
        }
    }
}
