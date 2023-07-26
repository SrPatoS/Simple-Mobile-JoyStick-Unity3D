using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SrPatoS.JoyStick.Touch
{
    public class TouchMoveInputBase : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        protected Vector2 _inputs;
        public void OnDrag(PointerEventData eventData)
        {
            _inputs = eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _inputs = Vector2.zero;
        }
    }
}