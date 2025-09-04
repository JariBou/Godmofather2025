using UnityEngine;

namespace _project.Scripts.Enigmas.PhEnigma
{
    [RequireComponent(typeof(Collider2D))]
    public class DropletScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}