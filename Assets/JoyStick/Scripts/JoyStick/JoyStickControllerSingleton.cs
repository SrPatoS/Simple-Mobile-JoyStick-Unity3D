using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SrPatoS.JoyStick.Core;

namespace SrPatoS.JoyStick.Models
{
    public class JoyStickControllerSingleton : JoyStickControllerBase
    {
        public static JoyStickControllerSingleton Instance;
        public static Vector2 GetInput { get; private set; }
        protected override void Awake()
        {
            base.Awake();

            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Update()
        {
            GetInput = _normalizedDirection;
        }
    }
}


