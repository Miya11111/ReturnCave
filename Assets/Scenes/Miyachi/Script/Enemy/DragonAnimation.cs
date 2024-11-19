using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour
{
    private Animator anim = null;

    void Start (){
        anim = GetComponent<Animator>();
    }
    //踏まれたときの処理
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "GroundCheck"){
            anim.SetTrigger("damage");
        }
    }
}
