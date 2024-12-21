using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChikuwa : MonoBehaviour
{
    Animator _animator;
    void Start (){
        _animator = GetComponent<Animator> ();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "GroundCheck"){
            _animator.enabled = true;
        }
    }

    //アニメーション終了時に呼び出される
    public void DestroyBlock(){
        Destroy(this.gameObject);
    }
}
