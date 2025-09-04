using UnityEngine;

public class GlassKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("wow");
        if (collision.CompareTag("Glass") || collision.CompareTag("Unconveyorable"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
