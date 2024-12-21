using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDisable : MonoBehaviour
{
    Animator _animator;

    void Start (){
        
        _animator = GetComponent<Animator> ();
    }
    public void StopAnimation(){
        _animator.enabled = false;
    }
}
