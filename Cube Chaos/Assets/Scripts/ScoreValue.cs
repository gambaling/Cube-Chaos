using UnityEngine;
using UnityEngine.UI;

public class ScoreValue : MonoBehaviour
{

    public Transform sameOverPlayer;
    public Text sameOverScoreText;

    public void SetText()
    {
        sameOverScoreText.text = sameOverPlayer.position.z.ToString("0");
    }
}
