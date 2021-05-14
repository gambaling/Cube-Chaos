using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    private GameObject player;
    public Text levelScoreText;
    public Text levelHighScore;

    private int actualScore;
    private int actualHighScore;

    private String nameActualLevelScore;

    public void SetLevelActualScore()
    {
        actualScore = Convert.ToInt32(player.transform.position.z);
        levelScoreText.text = actualScore.ToString();
    }

    public void SetLevelHighScore()
    {
        if (actualScore > actualHighScore)
        {
            PlayerPrefs.SetInt(nameActualLevelScore, actualScore);
            actualHighScore = actualScore;
            setActualHighScoreText();
        }

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nameActualLevelScore = "level-" + SceneManager.GetActiveScene().buildIndex + "-highScore";
        actualHighScore = PlayerPrefs.GetInt(nameActualLevelScore);
        setActualHighScoreText();
    }

    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().isDead())
        {
            SetLevelActualScore();
            SetLevelHighScore();
        }
    }

    private void setActualHighScoreText()
    {
        levelHighScore.text = "High Score " + actualHighScore.ToString();
    }

}
