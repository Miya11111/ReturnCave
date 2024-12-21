using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedileDitect : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D collider2D){
        if(collider2D.gameObject.tag == "Player"){
            Debug.Log("A");
            animator.enabled = true;
        }
    }
}
