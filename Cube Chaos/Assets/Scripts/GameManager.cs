using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    private float restarDelay = 1f;

    public GameObject completeLevelUI;
    public GameObject gameOverUI;

    private GameObject endPoint;

    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint");
    }

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
