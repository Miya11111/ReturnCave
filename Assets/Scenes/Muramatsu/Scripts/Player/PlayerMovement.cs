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
            Idle,       // �n��Ŗ�������
            Moving,     // �n��ō��E�ړ����
            InAir,      // �󒆂ŕ��V���
        };

        private PlayerMovementState _currentState;

        public bool     _isGrounded;
        private bool    _isRunning;
        private bool    _isClimb;
        public bool _isClimb_anim;
        public bool _isClimb_stop_anim;

        private Rigidbody2D _rb2d;

        [Header("��������") , SerializeField]
        private Vector2 _horizontalMoveForce = new Vector2(10.0f, 0);

        [Header("�_�b�V�����̑��x�W��"), SerializeField]
        private float _dushVelocityCoefficient = 1.25f;

        [Header("�W�����v�̋���"), SerializeField]
        private Vector2 _thrust = new Vector2(0.0f, 6.0f);

        [Header("�o�鑬��") , SerializeField]
        private Vector2 _verticalMoveForce = new Vector2(0, 10.0f);

        // �����ړ��̓��͂�ۑ�
        private float _horizontalInput = 0.0f;

        // �����ړ��̓��͂�ۑ�
        private float _verticalInput = 0.0f;

        [Header("�ړ����̌��E���x"), SerializeField]
        private Vector2 _movementLimitVelocity = new Vector2(5.0f, 20.0f);

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        // InputSystem����Ă΂�鍶�E�ړ��p�֐�
        public void OnMove(InputAction.CallbackContext context)
        {
            //Debug.Log("Player: on move");

            // �ړ��p�̓��͒l��ۑ�
            _horizontalInput = context.ReadValue<float>();
        }

        // InputSystem����Ă΂��W�����v�p�֐�
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (_isGrounded || _isClimb)
                {
                    //�u�W�����v�{�^���������Ɠo���Ԃ���������v����肽��
                    _isClimb = false;
                    //Debug.Log("Player: on jump");
                    _rb2d.AddForce(_thrust, ForceMode2D.Impulse);
                }
            }
        }

        // InputSystem����Ă΂��_�b�V���ړ��p�֐�
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

        // InputSystem����Ă΂�郍�[�v�o��p�֐�
        public void OnClimb(InputAction.CallbackContext context){
            if(_isClimb == true){
                _rb2d.gravityScale = 0;
                //�����Ă���Ƃ�
                if(context.phase == InputActionPhase.Performed){
                    // Debug.Log("CLIMB");
                    _isClimb_anim = true;
                    _rb2d.velocity = Vector2.zero;
                    // �ړ��p�̓��͒l��ۑ�
                    _verticalInput = context.ReadValue<float>();
                    _isClimb_stop_anim = false;
                }
                //�~�܂��Ă���Ƃ�
                else if(context.phase == InputActionPhase.Canceled){
                    // Debug.Log("NOT CLIMB");
                    _rb2d.velocity = Vector2.zero;
                    _verticalInput = 0;
                    _isClimb_stop_anim = true;
                }
            }
        }

        // Player�����n���Ă���Ԃ̃t���[���Ɏ��s(����̂��߂ɑ�����BoxCollider2D���g�p)
        private void OnTriggerStay2D(Collider2D collision)
        {
            //�v���C���[�Ɠo�����̂��d�Ȃ��Ă�������s
            if(collision.gameObject.tag == "Climb"){
                //Debug.Log("CLIMB");
                _isClimb = true;
            }
            else{
                _isGrounded = true;
            }
        }

        // Player���n�ʂ��痣�ꂽ�t���[���Ɏ��s(����̂��߂ɑ�����BoxCollider2D���g�p)
        private void OnTriggerExit2D(Collider2D collision)
        {
            //Debug.Log("Player: Ground Exit");

            //�v���C���[���o�����̂Ɨ��ꂽ����s
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

        //�G�ɓ��������Ƃ��Ɏ��s(���S����)
        private void OnCollisionEnter2D(Collision2D collision){
            if(collision.gameObject.tag == "Enemy"){
                Debug.Log("Player: Dead");
                Time.timeScale = 0;
            }
        }

        // Player�̏�Ԃ��X�V����
        private void UpdatePlayerMovementState(PlayerMovementState newState)
        {
            //Debug.Log("Player: State is " + newState);

            _currentState = newState;
        }

        // Player�̈ړ���Ԃ��Q�Ƃ���
        public PlayerMovementState GetCurrentPlayerMovementState()
        {
            return _currentState;
        }

        private void FixedUpdate()
        {
            // raycast�Őڒn���������������
            _rb2d.AddForce(_horizontalInput * _horizontalMoveForce);

            if(_isRunning)
            {
                // �ړ����x������l�𒴂��Ă���ꍇ
                if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x * _dushVelocityCoefficient)
                {
                    // �ړ����x���K��l�ɒ���
                    _rb2d.velocity = new Vector2(_horizontalInput * _movementLimitVelocity.x * _dushVelocityCoefficient, _rb2d.velocity.y);
                }
            }
            else
            {
                // �ړ����x������l�𒴂��Ă���ꍇ
                if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x)
                {
                    // �ړ����x���K��l�ɒ���
                    _rb2d.velocity = new Vector2(_horizontalInput * _movementLimitVelocity.x, _rb2d.velocity.y);
                }
            }

            //���[�v��o��
            if (_isClimb){
                _rb2d.AddForce(_verticalInput * _verticalMoveForce);
                // �ړ����x������l�𒴂��Ă���ꍇ
                if (Mathf.Abs(_rb2d.velocity.y) >= _movementLimitVelocity.y)
                {
                    // �ړ����x���K��l�ɒ���
                    _rb2d.velocity = new Vector2(0, _verticalInput * _movementLimitVelocity.y);
                }
            }
        }
    }
}
