using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<InputAction.CallbackContext> RightArrowPressed;
        public static event Action<InputAction.CallbackContext> FirstLeftButtonPressed;
        public static event Action<InputAction.CallbackContext> SecondLeftButtonPressed;
        public static event Action<InputAction.CallbackContext> ThirdLeftButtonPressed;
        public static event Action<InputAction.CallbackContext> FirstRightButtonPressed;
        public static event Action<InputAction.CallbackContext> SecondRightButtonPressed;
        public static event Action<InputAction.CallbackContext> ThirdRightButtonPressed;
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

        private static void OnFirstLeftButonPressed(InputAction.CallbackContext obj)
        {
            FirstLeftButtonPressed?.Invoke(obj);
        }

        private static void OnSecondLeftButtonPressed(InputAction.CallbackContext obj)
        {
            SecondLeftButtonPressed?.Invoke(obj);
        }

        private static void OnThirdLeftButtonPressed(InputAction.CallbackContext obj)
        {
            ThirdLeftButtonPressed?.Invoke(obj);
        }

        private static void OnFirstRightButtonPressed(InputAction.CallbackContext obj)
        {
            FirstRightButtonPressed?.Invoke(obj);
        }

        private static void OnSecondRightButtonPressed(InputAction.CallbackContext obj)
        {
            SecondRightButtonPressed?.Invoke(obj);
        }

        private static void OnThirdRightButtonPressed(InputAction.CallbackContext obj)
        {
            ThirdRightButtonPressed?.Invoke(obj);
        }
    }
}