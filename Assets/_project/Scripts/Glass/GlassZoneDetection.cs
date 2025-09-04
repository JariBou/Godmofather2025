#nullable enable
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts.Glass
{
    public class GlassZoneDetection : MonoBehaviour
    {
        private bool _inzone = false;
        private Queue<GameObject> _glassesEntered = new();
        private GameObject? _currentGlass;
        
        [SerializeField, InfoBox("In order of left part: left to right")]
        private List<Transform> _targets = new();
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Glass"))
            {
                _glassesEntered.Enqueue(collision.gameObject);
                _inzone = true;
                _currentGlass = collision.gameObject; 
                Debug.Log("In the zone with " + _currentGlass.name);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Glass") && collision.gameObject == _currentGlass)
            {
                _glassesEntered.Dequeue();
                _inzone = false;
                Debug.Log("Left the zone");
                _currentGlass = null; // on oublie l'objet
            }
        }

        public void OnFirstAction(InputAction.CallbackContext obj)
        {
            if (!_glassesEntered.TryPeek(out GameObject? peek)) return;
            
            //TODO: check if glass is goood
            if (true)
            {
                // Move Glass
                // peek.GetComponent<Glass>().Goto();
                peek.transform.position = _targets[0].transform.position;
                Destroy(peek, .3f);
                // _glassesEntered.Dequeue();
            }
        }

        public void OnSecondAction(InputAction.CallbackContext obj)
        {
            if (!_glassesEntered.TryPeek(out GameObject? peek)) return;

            //TODO: check if glass is goood
            if (true)
            {
                // Move Glass
                // peek.GetComponent<Glass>().Goto();
                peek.transform.position = _targets[1].transform.position;
                Destroy(peek, .3f);
                // _glassesEntered.Dequeue();
            }
        }

        public void OnThirdAction(InputAction.CallbackContext obj)
        {
            if (!_glassesEntered.TryPeek(out GameObject? peek)) return;

            //TODO: check if glass is goood
            if (true)
            {
                // Move Glass
                // peek.GetComponent<Glass>().Goto();
                peek.transform.position = _targets[2].transform.position;
                Destroy(peek, .3f);
                // _glassesEntered.Dequeue();
            }
        }
    
        private void Changepose()
        {
            if (_inzone && _currentGlass != null)
            {
                Debug.Log("Change position of " + _currentGlass.name);
                // Exemple de changement de position
                _currentGlass.transform.position += new Vector3(1, 0, 0); // déplace l'objet de 1 unité vers la droite
            }
        }
    }
}