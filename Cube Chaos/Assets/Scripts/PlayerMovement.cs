using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float zAxisForce = 4000f;
    public float xAxisForce = 100f;
    private bool deadByCollision;

    public Explosion explosion;

    public void MoveToTheRigth ()
    {
        playerRB.AddForce(xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveToTheLeft()
    {
        playerRB.AddForce(-xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }


    void FixedUpdate()
    {
        // Makes the player moves forward;
        playerRB.AddForce(0, 0, zAxisForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            MoveToTheRigth();
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            MoveToTheLeft();
        }

        // Makes the player die if he falls off the plataform
        if (isDead())
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public bool isDead()
    {
        return playerRB.position.y < -1f || deadByCollision;
    }

    public void stopPlayer()
    {
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void setDeadByCollision()
    {
        this.enabled = false;
        deadByCollision = true;
        explosion.Explode();
    }
}
