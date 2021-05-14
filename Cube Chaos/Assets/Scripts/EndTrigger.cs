using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().stopPlayer();
    }
}
