using UnityEngine;

public class GlassKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Glass"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
