using UnityEngine;

public class ConveyorMoveGlass : MonoBehaviour
{
    [SerializeField] private Collider2D _conveyorCollider;
    [SerializeField] private float _conveyorSpeed;
    [SerializeField] private float _glassPositionY;

    private void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("wow");
        if (collision.CompareTag("Glass"))
        {
            collision.transform.position = new Vector3(collision.transform.position.x + _conveyorSpeed * Time.deltaTime, _glassPositionY + transform.position.y, collision.transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0, _glassPositionY + transform.position.y, 0), 0.5f);
    }
}
