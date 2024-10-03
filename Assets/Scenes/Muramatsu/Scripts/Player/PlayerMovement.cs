using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb2d;

        [Header("歩く速さ") , SerializeField]
        private Vector2 _horizontalMoveForce = new Vector2(10.0f, 0);
        
        [Header("ジャンプの強さ"), SerializeField]
        private Vector2 _thrust = new Vector2(0.0f, 6.0f);

        // 水平移動の入力を保存
        private float _horizontalInput = 0.0f;

        [Header("通常移動時の限界速度"), SerializeField]
        private Vector2 _movementLimitVelocity　= new Vector2(5.0f, 20.0f);

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        // InputSystemから呼ばれる
        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log("on move");

            // 移動用の入力値を保存
            _horizontalInput = context.ReadValue<float>();

            
            //_rb2d.AddForce(_horizontalInput * _horizontalMoveForce);
            
        }

        // InputSystemから呼ばれる
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Debug.Log("on jump");

                _rb2d.AddForce(_thrust, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            _rb2d.AddForce(_horizontalInput * _horizontalMoveForce);

            if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x)
            {
                _rb2d.velocity = new Vector2(_horizontalInput * _movementLimitVelocity.x, _rb2d.velocity.y);
            }
        }
    }

}
