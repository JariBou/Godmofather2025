using UnityEngine;

public class AddUnconveyorableTag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass"))
        {
            collision.tag = "Unconveyorable";
        }
    }
}
