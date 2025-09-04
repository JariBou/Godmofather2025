using UnityEngine;

public class ConveyorMoveGlass : MonoBehaviour
{
    [SerializeField] private Collider2D _conveyorCollider;
    [SerializeField] private float _conveyorSpeed;
    [SerializeField] private float _glassPositionY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") && !collision.CompareTag("Unconveyorable"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") && !collision.CompareTag("Unconveyorable"))
        {
            collision.transform.position = new Vector3(collision.transform.position.x + _conveyorSpeed * Time.deltaTime, _glassPositionY + transform.position.y, collision.transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.isTrigger = false;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityX = _conveyorSpeed;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(50 * - Mathf.Sign(_conveyorSpeed), 100 * - Mathf.Sign(_conveyorSpeed));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0, _glassPositionY + transform.position.y, 0), 0.5f);
    }
}
