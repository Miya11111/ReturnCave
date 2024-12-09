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
            Moving,     // 地上で左右移動状態
            InAir,      // 空中で浮遊状態
        };

        private PlayerMovementState _currentState;

        public bool     _isGrounded;
        private bool    _isRunning;
        private bool    _isClimb;
        public bool _isClimb_anim;
        public bool _isClimb_stop_anim;

        private Rigidbody2D _rb2d;

        [Header("歩く速さ") , SerializeField]
        private Vector2 _horizontalMoveForce = new Vector2(10.0f, 0);

        [Header("ダッシュ時の速度係数"), SerializeField]
        private float _dushVelocityCoefficient = 1.25f;

        [Header("ジャンプの強さ"), SerializeField]
        private Vector2 _thrust = new Vector2(0.0f, 6.0f);

        [Header("登る速さ") , SerializeField]
        private Vector2 _verticalMoveForce = new Vector2(0, 10.0f);

        // 水平移動の入力を保存
        private float _horizontalInput = 0.0f;

        // 垂直移動の入力を保存
        private float _verticalInput = 0.0f;

        [Header("移動時の限界速度"), SerializeField]
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
                if (_isGrounded || _isClimb)
                {
                    //「ジャンプボタンを押すと登り状態を解除する」を作りたい
                    _isClimb = false;
                    //Debug.Log("Player: on jump");
                    _rb2d.AddForce(_thrust, ForceMode2D.Impulse);
                }
            }
        }

        // InputSystemから呼ばれるダッシュ移動用関数
        public void OnDush(InputAction.CallbackContext context)
        {
            //Debug.Log("Player: on dush");

            if (context.phase == InputActionPhase.Performed)
            {
                _isRunning = true;
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                _isRunning = false;
            }
        }

        // InputSystemから呼ばれるロープ登る用関数
        public void OnClimb(InputAction.CallbackContext context){
            if(_isClimb == true){
                _rb2d.gravityScale = 0;
                //動いているとき
                if(context.phase == InputActionPhase.Performed){
                    // Debug.Log("CLIMB");
                    _isClimb_anim = true;
                    _rb2d.velocity = Vector2.zero;
                    // 移動用の入力値を保存
                    _verticalInput = context.ReadValue<float>();
                    _isClimb_stop_anim = false;
                }
                //止まっているとき
                else if(context.phase == InputActionPhase.Canceled){
                    // Debug.Log("NOT CLIMB");
                    _rb2d.velocity = Vector2.zero;
                    _verticalInput = 0;
                    _isClimb_stop_anim = true;
                }
            }
        }

        // Playerが着地している間のフレームに実行(判定のために足元のBoxCollider2Dを使用)
        private void OnTriggerStay2D(Collider2D collision)
        {
            //プレイヤーと登れるものが重なっていたら実行
            if(collision.gameObject.tag == "Climb"){
                //Debug.Log("CLIMB");
                _isClimb = true;
            }
            else{
                _isGrounded = true;
            }
        }

        // Playerが地面から離れたフレームに実行(判定のために足元のBoxCollider2Dを使用)
        private void OnTriggerExit2D(Collider2D collision)
        {
            //Debug.Log("Player: Ground Exit");

            //プレイヤーが登れるものと離れたら実行
            if(collision.gameObject.tag == "Climb"){
                _isClimb = false;
                _isClimb_anim = false;
                _verticalInput = 0;
                _rb2d.gravityScale = 1;
            }
            else{
                _isGrounded = false;
            }
        }

        //敵に当たったときに実行(死亡判定)
        private void OnCollisionEnter2D(Collision2D collision){
            if(collision.gameObject.tag == "Enemy"){
                Debug.Log("Player: Dead");
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

            if(_isRunning)
            {
                // 移動速度が既定値を超えている場合
                if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x * _dushVelocityCoefficient)
                {
                    // 移動速度を規定値に直す
                    _rb2d.velocity = new Vector2(_horizontalInput * _movementLimitVelocity.x * _dushVelocityCoefficient, _rb2d.velocity.y);
                }
            }
            else
            {
                // 移動速度が既定値を超えている場合
                if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x)
                {
                    // 移動速度を規定値に直す
                    _rb2d.velocity = new Vector2(_horizontalInput * _movementLimitVelocity.x, _rb2d.velocity.y);
                }
            }

            //ロープを登る
            if (_isClimb){
                _rb2d.AddForce(_verticalInput * _verticalMoveForce);
                // 移動速度が既定値を超えている場合
                if (Mathf.Abs(_rb2d.velocity.y) >= _movementLimitVelocity.y)
                {
                    // 移動速度を規定値に直す
                    _rb2d.velocity = new Vector2(0, _verticalInput * _movementLimitVelocity.y);
                }
            }
        }
    }
}
