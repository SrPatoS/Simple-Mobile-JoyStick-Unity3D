using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SrPatoS.JoyStick.Core
{
    public class JoyStickControllerBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Header("Setup")]
        [SerializeField] private Transform _transform;
        [SerializeField] private float joystickRadius = 100f;
        protected Vector2 _normalizedDirection;
        private Vector3 _initialPosition;
        private Vector3 _pointerOffset;
        private bool _isHolding;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isHolding = true;
            _pointerOffset = _transform.localPosition - Input.mousePosition;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isHolding = false;
            _transform.localPosition = _initialPosition;
            _normalizedDirection = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isHolding)
            {
                Vector3 pointerPosition = Input.mousePosition + _pointerOffset;
                Vector3 clampedPosition = _initialPosition + Vector3.ClampMagnitude(pointerPosition - _initialPosition, joystickRadius);

                _transform.localPosition = clampedPosition;

                Vector3 direction = (_transform.localPosition - _initialPosition).normalized;
                float magnitude = Vector3.Distance(_initialPosition, _transform.localPosition) / joystickRadius;
                _normalizedDirection = new Vector2(direction.x, direction.y) * magnitude;
            }
        }

        protected virtual void Awake()
        {
            _initialPosition = _transform.localPosition;
            _normalizedDirection = Vector2.zero;
        }
    }
}