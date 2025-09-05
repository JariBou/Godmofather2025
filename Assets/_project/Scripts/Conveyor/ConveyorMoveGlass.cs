using System.Collections.Generic;
using _project.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConveyorMoveGlass : MonoBehaviour
{
    [SerializeField] private int _conveyorSpeedDirection = 1;
    [SerializeField] private float _glassPositionY;
    private float _conveyorSpeed;
    
    private static Queue<int> _sharedGlassesRemembered = new(10);

    private void Start()
    {
        AudioManager.Instance.Play("conveyor belt");
        AudioManager.Instance.Play("musique");
        AudioManager.Instance.Play("Ambiance grotte");
    }

    public void SetSpeed(float speed)
    {
        _conveyorSpeed = speed * _conveyorSpeedDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") && !collision.CompareTag("Unconveyorable") && !DoesRememberGlass(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") && !collision.CompareTag("Unconveyorable") && !DoesRememberGlass(collision.gameObject))
        {
            collision.transform.position = new Vector3(collision.transform.position.x + _conveyorSpeed * Time.deltaTime, _glassPositionY + transform.position.y, collision.transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass") && !DoesRememberGlass(collision.gameObject))
        {
            RememberGlass(collision.gameObject);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.isTrigger = false;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityX = _conveyorSpeed;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(50 * - Mathf.Sign(_conveyorSpeed), 100 * - Mathf.Sign(_conveyorSpeed));
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0, _glassPositionY + transform.position.y, 0), 0.5f);
    }
}
