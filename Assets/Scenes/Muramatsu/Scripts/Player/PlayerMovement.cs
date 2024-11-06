using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;
using UnityEngine.UIElements;
using System;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public enum PlayerMovementState
        {
            Idle,       // 地上で無操作状態
            Walking,    // 地上で左右移動状態
            Running,    // 地上で走っている状態
        };

        private PlayerMovementState _currentState;

        private bool _isGrounded;
        public bool IsGrounded { get { return _isGrounded; } }

        private Rigidbody2D _rb2d;

        [Header("歩く速さ") , SerializeField]
        private Vector2 _horizontalMoveForce = new Vector2(10.0f, 0);
        
        [Header("ジャンプの強さ"), SerializeField]
        private Vector2 _thrust = new Vector2(0.0f, 6.0f);

        // 水平移動の入力を保存
        private float _horizontalInput = 0.0f;

        [Header("通常移動時の限界速度"), SerializeField]
        private Vector2 _movementLimitVelocity = new Vector2(5.0f, 20.0f);

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        // InputSystemから呼ばれる左右移動用関数
        public void OnMove(InputAction.CallbackContext context)
        {
            //Debug.Log("Player: on move");

            // 移動用の入力値を保存
            _horizontalInput = context.ReadValue<float>();
        }

        // InputSystemから呼ばれるジャンプ用関数
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (_isGrounded)
                {
                    //Debug.Log("Player: on jump");
                    _rb2d.AddForce(_thrust, ForceMode2D.Impulse);
                }
            }
        }

        // Playerが着地している間のフレームに実行(判定のために足元のBoxCollider2Dを使用)
        private void OnTriggerStay2D(Collider2D collision)
        {
            //Debug.Log("Player: Grounding");

            _isGrounded = true;
        }

        // Playerが地面から離れたフレームに実行(判定のために足元のBoxCollider2Dを使用)
        private void OnTriggerExit2D(Collider2D collision)
        {
            //Debug.Log("Player: Ground Exit");

            _isGrounded = false;
        }

        //敵に当たったときに実行(死亡判定)
        private void OnCollisionEnter2D(Collision2D collision){
            if(collision.gameObject.tag == "Enemy"){
                Debug.Log("Player: Dead");
                Destroy(this);
                Time.timeScale = 0;
            }
        }

        // Playerの状態を更新する
        private void UpdatePlayerMovementState(PlayerMovementState newState)
        {
            //Debug.Log("Player: State is " + newState);

            _currentState = newState;
        }

        // Playerの移動状態を参照する
        public PlayerMovementState GetCurrentPlayerMovementState()
        {
            return _currentState;
        }

        private void FixedUpdate()
        {
            // raycastで接地判定を実装したい

            _rb2d.AddForce(_horizontalInput * _horizontalMoveForce);

            // 移動速度が既定値を超えている場合
            if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x)
            {
                // 移動速度を規定値に直す
                _rb2d.velocity = new Vector2(_horizontalInput * _movementLimitVelocity.x, _rb2d.velocity.y);
            }
        }
    }
}
