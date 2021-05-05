using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float zAxisForce = 4000f;
    public float xAxisForce = 100f;

    public void MoveToTheRigth ()
    {
        playerRB.AddForce(xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    public void MoveToTheLeft()
    {
        playerRB.AddForce(-xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Add force foraward 
        playerRB.AddForce(0, 0, zAxisForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            MoveToTheRigth();
        }

        if (Input.GetKey("a"))
        {
            MoveToTheLeft();
        }

        // Makes the player die if he falls off the plataform
        if (playerRB.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
