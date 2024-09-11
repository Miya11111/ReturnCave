using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Animator player_animator = default;

        private void Awake()
        {
            player_animator = GetComponent<Animator>();
        }

        public void OnWalk(InputAction.CallbackContext context)
        {
            Debug.Log("walking now");
            player_animator.SetBool("is_moving", true);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("jumping now");
            player_animator.SetTrigger("jump_trigger");
        }
    }
}
