#nullable enable
using System;
using System.Collections.Generic;
using _project.Scripts.Managers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts.Glass
{
    public class GlassZoneDetection : MonoBehaviour
    {
        private static Queue<int> _sharedGlassesRemembered = new(10);
        
        private Queue<Glass> _glassesEntered = new();
        
        [SerializeField, InfoBox("In order of left part: left to right")]
        private List<Transform> _targets = new();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Glass") && !DoesRememberGlass(collision.gameObject))
            {
                _glassesEntered.Enqueue(collision.gameObject.GetComponent<Glass>());
                Debug.Log("In the zone with " + collision.gameObject.name);
                
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Glass") && _glassesEntered.TryPeek(out Glass? glass) && collision.gameObject.GetComponent<Glass>() == glass && !DoesRememberGlass(collision.gameObject))
            {
                _glassesEntered.Dequeue();
                RememberGlass(glass.gameObject);
                Debug.Log("Left the zone");
            }
        }

        public void OnFirstAction(InputAction.CallbackContext obj)
        {
            if (!obj.performed) return;
            AudioManager.Instance.Play("button select");

            if (!_glassesEntered.TryPeek(out Glass? peek)) return;
            
            //TODO: check if glass is goood
            if (peek.GetGlassType() == Glass.Type.GREEN)
            {
                // Move Glass
                try
                {
                    peek.MoveTo(_targets[0].transform.position, .75f);
                    AudioManager.Instance.Play("eau qui bout");
                    AudioManager.Instance.Play("feu,gaz");
                    //increment score
                    GameManager.AddScore(GameManager.GlassScoreValue);
                }
                catch (Exception e)
                {
                    // ignored
                }

                // peek.transform.position = _targets[0].transform.position;
                // Destroy(peek.gameObject, .3f);
                AudioManager.Instance.Play("eau qui bout");
                AudioManager.Instance.Play("feu,gaz");
                _glassesEntered.Dequeue();
            }
            else
            {
                try
                {
                    peek.Disable();
                }
                catch (Exception e)
                {
                    // ignored
                }
                _glassesEntered.Dequeue();
            }
        }

        public void OnSecondAction(InputAction.CallbackContext obj)
        {
            if (!obj.performed) return;
            AudioManager.Instance.Play("button select");

            if (!_glassesEntered.TryPeek(out Glass? peek)) return;

            //TODO: check if glass is goood
            if (peek.GetGlassType() == Glass.Type.RED)
            {
                // Move Glass
                try
                {
                    peek.MoveTo(_targets[1].transform.position, .75f);
                    // peek.transform.position = _targets[1].transform.position;
                    // Destroy(peek.gameObject, .3f);
                    AudioManager.Instance.Play("feuille");
                    GameManager.AddScore(GameManager.GlassScoreValue);
                }
                catch (Exception e)
                {
                    // ignored
                }

                _glassesEntered.Dequeue();
            }
            else
            {
                try
                {
                    peek.Disable();
                }
                catch (Exception e)
                {
                    // ignored
                }
                _glassesEntered.Dequeue();
            }
        }

        public void OnThirdAction(InputAction.CallbackContext obj)
        {
            if (!obj.performed) return;
            AudioManager.Instance.Play("button select");
            if (!_glassesEntered.TryPeek(out Glass? peek)) return;

            //TODO: check if glass is goood
            if (peek.GetGlassType() == Glass.Type.BLUE)
            {
                // Move Glass
                try
                {
                    peek.MoveTo(_targets[2].transform.position, .75f);
                    // peek.transform.position = _targets[2].transform.position;
                    // Destroy(peek.gameObject, .3f);
                    AudioManager.Instance.Play("goutte d_eau");
                    GameManager.AddScore(GameManager.GlassScoreValue);
                }
                catch (Exception e)
                {
                    // ignored
                }

                _glassesEntered.Dequeue();
            }
            else
            {
                try
                {
                    peek.Disable();
                }
                catch (Exception e)
                {
                    // ignored
                }

                _glassesEntered.Dequeue();
            }
        }
        
        
        private void RememberGlass(GameObject glass)
        {
            if (_sharedGlassesRemembered.Count > 10) _sharedGlassesRemembered.Dequeue();
            _sharedGlassesRemembered.Enqueue(glass.GetInstanceID());
        }

        private bool DoesRememberGlass(GameObject glass)
        {
            return _sharedGlassesRemembered.Contains(glass.GetInstanceID());
        }

    }
}