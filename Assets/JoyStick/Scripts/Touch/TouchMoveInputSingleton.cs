using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SrPatoS.JoyStick.Touch
{
    public class TouchMoveInputSingleton : TouchMoveInputBase
    {
        public static TouchMoveInputSingleton Instance;
        public static Vector2 GetTouchInputs { get; private set; }
        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Update()
        {
            GetTouchInputs = _inputs;
        }
    }
}

