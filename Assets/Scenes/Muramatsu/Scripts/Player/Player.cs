using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        //private Animator playerAnimator = default;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();

            //playerAnimator = GetComponent<Animator>();
        }
    }
}
