using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        DisablePauseMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenu.activeSelf == false)
            {
                EnablePauseMenu();
            }
            else
            {
                DisablePauseMenu();
            }
        }
    }

   public void EnablePauseMenu()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        _pauseMenu.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        _pauseMenu.SetActive(false);
    }
}
