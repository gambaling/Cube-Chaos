using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button button;
    public void SelectLevel()
    {
        // Assign Button text component !NAME! (not text itself) converted to string to lvl variable;
        string lvl = button.GetComponentInChildren<Text>().ToString();
        // Load scene based on Button text component !NAME! first character converted from char to string then to int + 1 (Because scene 0 is Main Menu and scene 1 is Level selection scene);
        SceneManager.LoadScene(Int16.Parse(lvl[0].ToString()) + 1);
    }

}
