using _project.Scripts;
using _project.Scripts.Managers;
using UnityEngine;

public class GlassKiller : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") || collision.CompareTag("Unconveyorable"))
        {
            PlayRandomGlassSound();

            GameManager.RemoveLife();
            Destroy(collision.gameObject);
        }
    }
    private void PlayRandomGlassSound()
    {
        if (AudioManager.Instance == null || AudioManager.Instance.Sounds.Length == 0)
            return;

        // Filtre les sons qui commencent par "Verre"
        var verreSounds = System.Array.FindAll(AudioManager.Instance.Sounds, s => s.name.StartsWith("verre"));

        if (verreSounds.Length == 0) return;

        // Choisit un son au hasard parmi les sons filtrés
        int randIndex = Random.Range(0, verreSounds.Length);
        AudioManager.Instance.Play(verreSounds[randIndex].name);
    }
}
