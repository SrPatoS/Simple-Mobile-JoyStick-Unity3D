using System.Collections;
using System.Collections.Generic;
using SrPatoS.JoyStick.Models;
using SrPatoS.JoyStick.Touch;
using UnityEngine;

namespace SrPatoS.JoyStick.Demo
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private TouchClickEvent _jumpClick;
        private float _verticalInput;
        private float _horizontalInput;
        private void Awake()
        {
            _jumpClick.OnClickEvent.AddListener(delegate { Jump(); });
        }

        private void Jump()
        {
            _playerMove.OnJump();
        }

        private void Update()
        {
            _verticalInput = JoyStickControllerSingleton.GetInput.y;
            _horizontalInput = JoyStickControllerSingleton.GetInput.x;

            _playerMove.Move(_horizontalInput, _verticalInput);
        }
    }
}