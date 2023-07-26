using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SrPatoS.JoyStick.Demo
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private CharacterController _controller;
        [Header("Gravity")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheckTransform;
        [SerializeField] private float _radiusCheck = 0.4f;
        [SerializeField] private float _gravityForce = -9.81f;
        [SerializeField] private float _playerVelocity = 3.5f;
        [SerializeField] private float _jumpForce = 5f;
        private bool _isGrounded;
        private Vector3 _velocity;

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(_groundCheckTransform.position, _radiusCheck, _groundLayer);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump();
            }

            ApplyGravity();
        }

        public void Move(float x, float y)
        {
            var move = transform.right * x + transform.forward * y;
            _controller.Move(move * (Time.deltaTime * _playerVelocity));
        }

        public void OnJump()
        {
            if (_isGrounded)
                _velocity.y = Mathf.Sqrt(_jumpForce * -2 * _gravityForce);
        }

        private void ApplyGravity()
        {
            _velocity.y += _gravityForce * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}