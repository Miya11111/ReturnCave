using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

namespace Player
{
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerMovement playerMovement;

        private Animator player_animator = default;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            playerMovement = GetComponent<PlayerMovement>();

            //player_animator = GetComponent<Animator>();
        }

        
    }

    public class PlayerInput : MonoBehaviour
    {
        
    }

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rb;

        [SerializeField] private Vector3 walkForce = new Vector3(1.0f, 0, 0);
        [SerializeField] private Vector3 thrust = new Vector3(0, 0, 5.0f);

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log("on move");

            rb.AddForce(walkForce);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                Debug.Log("on jump");

                rb.AddForce(thrust, ForceMode.Impulse);
            }
        }
    }
}
