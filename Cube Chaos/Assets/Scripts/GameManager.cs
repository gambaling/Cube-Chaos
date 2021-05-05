using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restarDelay = 1f;

    public GameObject completeLevelUI;

    public GameObject gameOverUI;

    public GameObject endPoint;

    public void CompleteLevel ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            completeLevelUI.SetActive(true);
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            endPoint.SetActive(false);
            Invoke("GameOver", restarDelay);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }


}
