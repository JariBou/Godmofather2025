using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _playSceneName;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(_playSceneName);
        }
    }
}
