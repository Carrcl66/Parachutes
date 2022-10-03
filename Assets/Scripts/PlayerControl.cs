using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public KeyCode moveUp, moveDown, moveLeft, moveRight; 

    public float speedX = 0, speedY = 0;
    public bool linearMovement = true;

    public Camera mainCam;

    public static int score = 0;

    private Rigidbody2D rbody;

    // Initialization function
    void Start()
    {
        // store the rigid body in an attribute for easier access.
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the player in the 4 directions based on the keys we set up for it
        if (Input.GetKey(moveUp))
        {
            if (linearMovement) // simple constant velocity
                rbody.velocity = new Vector2(0f, speedY);
            else // if we were going to use a force instead
            {
                if (rbody.velocity.y < 0.2f*speedY)
                    rbody.velocity = new Vector2(0f, 0.2f * speedY);
                rbody.AddForce(new Vector2(0f, speedY));
            }
        }
        else if (Input.GetKey(moveDown))
        {
            if (linearMovement)
                rbody.velocity = new Vector2(0f, -speedY);
            else
            {
                if (rbody.velocity.y > -0.2f * speedY)
                    rbody.velocity = new Vector2(0f, -0.2f * speedY);
                rbody.AddForce(new Vector2(0f, -speedY));
            }
        }
        else if (Input.GetKey(moveLeft))
        {
            if (linearMovement)
                rbody.velocity = new Vector2(-speedX, 0f);
            else
            {
                if (rbody.velocity.x > -0.2f * speedX)
                    rbody.velocity = new Vector2(-0.2f * speedX, 0f);
                rbody.AddForce(new Vector2(-speedX, 0f));
            }
        }
        else if (Input.GetKey(moveRight))
        {
            if (linearMovement)
                rbody.velocity = new Vector2(speedX, 0f);
            else
            {
                if (rbody.velocity.x < 0.2 * speedX)
                    rbody.velocity = new Vector2(0.2f * speedX, 0f);
                rbody.AddForce(new Vector2(speedX, 0f));
            }
        }
        else
        {
            // no input, reset the speed
            rbody.velocity = new Vector2(0f, 0f);
        }
        AdjustPosition();
    }

    // function to make sure the player doesn't go off the screen
    void AdjustPosition()
    {
        Vector3 screenPos = mainCam.WorldToScreenPoint(transform.position);
        Vector3 topScreen = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Vector3 bottomScreen = mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        // vertical adjustment
        if (screenPos.y > Screen.height)
            transform.position = new Vector3(transform.position.x, topScreen.y, transform.position.z);
        else if (screenPos.y < 0)
            transform.position = new Vector3(transform.position.x, bottomScreen.y, transform.position.z);
        // student: add some code for the horizontal
    }
}