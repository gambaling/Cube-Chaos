using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("space"))
        {
            LoadNextLevel();
        }

        if (Input.GetKey("escape"))
        {
            MainMenu();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
