using Unity.VisualScripting;
using System;
using _project.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputForAction : MonoBehaviour
{
    private bool Inzone = false;
    private GameObject currentGlass;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass"))
        {
            Inzone = true;
            currentGlass = collision.gameObject; 
            Debug.Log("In the zone with " + currentGlass.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") && collision.gameObject == currentGlass)
        {
            Inzone = false;
            Debug.Log("Left the zone");
            currentGlass = null; // on oublie l'objet
        }
    }

    private void OnEnable()
    {
        InputManager.LeftArrowPressed += OnLeftArrowPressed;
        InputManager.RightArrowPressed += OnRightArrowPressed;
    }

    private void OnDisable()
    {
        InputManager.LeftArrowPressed -= OnLeftArrowPressed;
        InputManager.RightArrowPressed -= OnRightArrowPressed;
    }

    private void OnLeftArrowPressed(InputAction.CallbackContext context)
    {
        if (Inzone && currentGlass != null)
        {
            Debug.Log("Left Arrow Pressed on " + currentGlass.name);

          
        }
    }

    private void OnRightArrowPressed(InputAction.CallbackContext context)
    {
        if (Inzone && currentGlass != null)
        {
            Debug.Log("Right Arrow Pressed on " + currentGlass.name);
            Changepose();

     
        }
    }
    
    private void Changepose()
    {
        if (Inzone && currentGlass != null)
        {
            Debug.Log("Change position of " + currentGlass.name);
            // Exemple de changement de position
            currentGlass.transform.position += new Vector3(1, 0, 0); // déplace l'objet de 1 unité vers la droite
        }
    }
}