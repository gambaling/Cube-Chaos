using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IPointerDownHandler
{
    public Rigidbody playerRB;

    public float zAxisForce = 4000f;
    public float xAxisForce = 100f;

    public Button leftButton;
    public Button rightButton;

    private string clickedButton;

    public void MoveToTheRigth ()
    {
        playerRB.AddForce(xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveToTheLeft()
    {
        playerRB.AddForce(-xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickedButton = this.gameObject.name;
    }

    // Update is called once per frame (Fixed is used before update whenever you mess with physics to help Unity indentify that and make more realistic);
    void FixedUpdate()
    {
        // Makes the player moves forward; 
        playerRB.AddForce(0, 0, zAxisForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey("right") || clickedButton == "rightButton")
        {
            MoveToTheRigth();
        }

        if (Input.GetKey("a") || Input.GetKey("left") || clickedButton == "leftButton")
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
