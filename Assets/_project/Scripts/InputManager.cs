using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<InputAction.CallbackContext> RightArrowPressed; 
        public static event Action<InputAction.CallbackContext> LeftArrowPressed; 
        public static event Action<InputAction.CallbackContext> LeftButtonPressed; 
        public static event Action<InputAction.CallbackContext> SpacePressed; 
            
        public IA_Player PlayerInputActions;


        private void Awake()
        {
            PlayerInputActions = new IA_Player();
        }


        public void OnLeftArrowPressed(InputAction.CallbackContext context)
        {
            LeftArrowPressed?.Invoke(context);
        }
        
        public void OnRightArrowPressed(InputAction.CallbackContext context)
        {
            RightArrowPressed?.Invoke(context);
        }
        
        public void OnLeftButtonPressed(InputAction.CallbackContext context)
        {
            LeftButtonPressed?.Invoke(context);
        }
        
        public void OnSpacePressed(InputAction.CallbackContext context)
        {
            SpacePressed?.Invoke(context);
        }
        
        private void OnEnable()
        {
            PlayerInputActions.Default.Enable();
        }

        private void OnDisable()
        {
            PlayerInputActions.Default.Disable();
        }
    }
}