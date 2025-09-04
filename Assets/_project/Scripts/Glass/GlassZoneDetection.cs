#nullable enable
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts.Glass
{
    public class GlassZoneDetection : MonoBehaviour
    {
        private Queue<Glass> _glassesEntered = new();
        
        [SerializeField, InfoBox("In order of left part: left to right")]
        private List<Transform> _targets = new();
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Glass"))
            {
                _glassesEntered.Enqueue(collision.gameObject.GetComponent<Glass>());
                Debug.Log("In the zone with " + collision.gameObject.name);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Glass") && collision.gameObject.GetComponent<Glass>() == _glassesEntered.Peek())
            {
                _glassesEntered.Dequeue();
                Debug.Log("Left the zone");
            }
        }

        public void OnFirstAction(InputAction.CallbackContext obj)
        {
            if (!obj.performed) return;
            if (!_glassesEntered.TryPeek(out Glass? peek)) return;
            
            //TODO: check if glass is goood
            if (peek.GetGlassType() == Glass.Type.RED)
            {
                // Move Glass
                // peek.GetComponent<Glass>().Goto();
                peek.transform.position = _targets[0].transform.position;
                Destroy(peek.gameObject, .3f);
                // _glassesEntered.Dequeue();
            }
        }

        public void OnSecondAction(InputAction.CallbackContext obj)
        {
            if (!obj.performed) return;
            if (!_glassesEntered.TryPeek(out Glass? peek)) return;

            //TODO: check if glass is goood
            if (peek.GetGlassType() == Glass.Type.GREEN)
            {
                // Move Glass
                // peek.GetComponent<Glass>().Goto();
                peek.transform.position = _targets[1].transform.position;
                Destroy(peek.gameObject, .3f);
                // _glassesEntered.Dequeue();
            }
        }

        public void OnThirdAction(InputAction.CallbackContext obj)
        {
            if (!obj.performed) return;
            if (!_glassesEntered.TryPeek(out Glass? peek)) return;

            //TODO: check if glass is goood
            if (peek.GetGlassType() == Glass.Type.BLUE)
            {
                // Move Glass
                // peek.GetComponent<Glass>().Goto();
                peek.transform.position = _targets[2].transform.position;
                Destroy(peek.gameObject, .3f);
                // _glassesEntered.Dequeue();
            }
        }
    }
}