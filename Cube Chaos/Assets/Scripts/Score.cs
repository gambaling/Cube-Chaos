using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text levelScoreText;
    public Text levelHighScore;

    private float actualScore;
    private float actualHighScore;

    public void SetLevelScore()
    {
        actualScore = player.position.z;
        levelScoreText.text = Convert.ToInt32(actualScore).ToString();
    }

    public void SetLevelHighScore()
    {
        if (actualScore > actualHighScore)
        {
            PlayerPrefs.SetFloat("LevelHighScore", actualScore);
            levelHighScore.text = "Level High Score " + Convert.ToUInt32(actualScore).ToString();
        }

    }

    private void Start()
    {
        actualHighScore = PlayerPrefs.GetInt("Level " + SceneManager.GetActiveScene().buildIndex + " HighScore", 0);
        levelHighScore.text = Convert.ToUInt32(actualHighScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SetLevelScore();
        SetLevelHighScore();
    }

}
