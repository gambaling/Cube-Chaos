using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button button;
    public void SelectLevel()
    {
        string lvl = button.GetComponentInChildren<Text>().ToString();
        SceneManager.LoadScene(Int16.Parse(lvl[0].ToString()) + 1);
        //SceneManager.LoadScene(Convert.ToInt32(button.GetComponentInChildren<Text>().ToString()));
    }

}
