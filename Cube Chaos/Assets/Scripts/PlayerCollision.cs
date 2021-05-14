using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement playerMovement;

    // Makes the player die if it hits an obstacle
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            playerMovement.setDeadByCollision();
            FindObjectOfType<GameManager>().EndGame();

            FindObjectOfType<AudioManager>().Play("CollisionSound");
        }
    }
}
