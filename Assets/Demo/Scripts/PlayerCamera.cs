using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SrPatoS.JoyStick.Touch;

namespace SrPatoS.JoyStick.Demo
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private Transform _cameraBody;
        [SerializeField] private Transform _playerBody;
        [SerializeField][Range(0.01f, 1f)] private float _sensitivity = 0.1f;
        private float _xRotation = 0f;
        private float _xMaxAngle = 90f;

        private void Update()
        {
            float inputX = TouchMoveInputSingleton.GetTouchInputs.x * _sensitivity * 100 * Time.deltaTime;
            float inputY = TouchMoveInputSingleton.GetTouchInputs.y * _sensitivity * 100 * Time.deltaTime;

            _xRotation -= inputY;
            _xRotation = Mathf.Clamp(_xRotation, -_xMaxAngle, _xMaxAngle);
            _cameraBody.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * inputX);
        }
    }

}