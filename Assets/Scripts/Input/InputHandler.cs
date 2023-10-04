using System;
using UnityEngine;

namespace Game.Inputer
{
    public class InputHandler
    {
        public event Action OnPress;
        public event Action OnUnpress;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0)) OnPress?.Invoke();
            if (Input.GetMouseButtonUp(0)) OnUnpress?.Invoke();
        }
    }
}