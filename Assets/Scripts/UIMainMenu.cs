using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public int SceneIndex = 0;

    public void Play()
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}