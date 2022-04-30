using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody jumperRigidbody;
    private PlayerInput playerInput;
    private NewControls playerInputActions;
    public bool isGrounded;
    private int count;
    public int lives = 3;
    public int fallDepth;
    private Vector3 startPos;
    public Text winText;
    public Text countText;
    public Text livesText;
    public Text gameOverText;

    private void Awake()
    {
        jumperRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new NewControls();
        playerInputActions.Jumper.Enable();
        //playerInputActions.Jumper.Jump.performed += Jump;
        

    }

    private void FixedUpdate()
    {
        //player movement
        Vector2 inputVector = playerInputActions.Jumper.Move.ReadValue<Vector2>();
        float speed = 0.4f;
        jumperRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Impulse);
        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //checks to see if the player is on the ground, if so lets player jump. (if above void, no jump)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (context.performed && isGrounded)
        {
            Debug.Log("Jump: " + context.phase);
            jumperRigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
        
    }

    //UI
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        //   if (count >= 11)
        //   {
        //       winText.text = "You Win!";
        //   }

        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            gameOverText.text = "Game Over!";
        }
    }

    //Player respawns after dying
    public void Respawn()
    {
        transform.position = startPos;
        lives--;
        SetCountText();
        if (lives <= 0)
        {
            this.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //kills and respawner the player if colldied with the below
        if (other.tag == "Enemy")
        {
            Respawn();
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("ChangeRot"))
        {
            Debug.Log("hit");
            transform.Rotate(0f, 90f, 0f);
        }
    }

    public void setSpawnPoint(Vector3 newPos)
    {
        startPos = newPos;
    }


}
