using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image _img;

    [SerializeField] private string _playSceneName;

    private void Start()
    {
        _img = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(_playSceneName);
        }
    }
}
