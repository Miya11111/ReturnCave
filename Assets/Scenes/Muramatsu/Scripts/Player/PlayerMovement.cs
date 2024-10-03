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

        [Header("��������") , SerializeField]
        private Vector2 _horizontalMoveForce = new Vector2(10.0f, 0);
        
        [Header("�W�����v�̋���"), SerializeField]
        private Vector2 _thrust = new Vector2(0.0f, 6.0f);

        // �����ړ��̓��͂�ۑ�
        private float _horizontalInput = 0.0f;

        [Header("�ʏ�ړ����̌��E���x"), SerializeField]
        private Vector2 _movementLimitVelocity�@= new Vector2(5.0f, 20.0f);

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        // InputSystem����Ă΂��
        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log("on move");

            // �ړ��p�̓��͒l��ۑ�
            _horizontalInput = context.ReadValue<float>();

            
            //_rb2d.AddForce(_horizontalInput * _horizontalMoveForce);
            
        }

        // InputSystem����Ă΂��
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
