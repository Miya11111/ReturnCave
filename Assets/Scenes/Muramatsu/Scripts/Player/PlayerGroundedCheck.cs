using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerGroundedCheck : MonoBehaviour
    {
        private GameObject parent;
        private Animator player_animator = default;

        private void Awake()
        {
            parent = transform.root.gameObject;
            player_animator = parent.GetComponent<Animator>();
        }

        // Player�����n�����t���[���Ɏ��s
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Enter!");
            player_animator.ResetTrigger("jump_trigger");
            player_animator.SetBool("is_grounded", true);
        }

        // Player���n�ʂ��痣�ꂽ�t���[���Ɏ��s
        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Exit!");
            player_animator.SetBool("is_grounded", false);
        }
    }
}
