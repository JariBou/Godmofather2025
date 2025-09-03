using UnityEngine;

public class GlassSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _glass;
    [SerializeField] private float _spawnCooldown;
    private float _timer;
    [SerializeField] private Vector3 _spawnPosition;

    private void Start()
    {
        _timer = _spawnCooldown;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_spawnCooldown <= _timer)
        {
            _timer = 0;
            SpawnGlass();
        }
    }

    void SpawnGlass()
    {
        GameObject newGlass = Instantiate(_glass);
        newGlass.transform.position = _spawnPosition;
        newGlass.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_spawnPosition, 1);
    }
}
