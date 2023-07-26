using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace SrPatoS.JoyStick.Touch
{
    public class TouchClickEvent : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent OnClickEvent;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent.Invoke();
        }
    }
}