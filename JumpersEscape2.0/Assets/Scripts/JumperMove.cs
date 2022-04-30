using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumperMove : MonoBehaviour
{
    
    //for camera
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    /*
    //for gravity
    public float gravity = -9.8f;
    Vector3 velocity;
    */
    private Rigidbody rigid_body;
    //public int speed = 5;
    private float jumpForce = 1;
    private int coins;
    public int lives = 3;
    public int fallDepth;
    public bool isGrounded;
    //private const int maxJump = 2;
    //private int currentJump = 0;
    private Vector3 startPos;
    public Text winText;
    public Text coinText;
    public Text livesText;
    public Text gameOverText;
    internal static object instance;
    public GameObject GameOverScreen;//Code added by E.C 
    public GameObject WinScreen;
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
        coins = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WinScreen.SetActive(false);
        GameOverScreen.SetActive(false); //Code added by E.C
       
        /*
        //gravity and jump
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * x + transform.forward * z;

        controller.Move(direction * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        */
        Move();
        Jump();

        

    }


   

    //player horizontal movement.
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }
        
        
        //makes the "a" key move the player left
        Vector3 temp;
        temp = transform.position;
        /*
        if (Input.GetKey("a"))
        {
            temp += transform.right * Time.deltaTime * -speed;
        }
        //makes the "d" key move the player right
        if (Input.GetKey("d"))
        {
            temp += transform.right * Time.deltaTime * speed;
        }
        //makes "w" key move player forward
        if (Input.GetKey("w"))
        {
            temp += transform.forward * Time.deltaTime * speed;
        }
        //makes "s" key move player back
        if (Input.GetKey("s"))
        {
            temp += transform.forward * Time.deltaTime * -speed;
        }
        */
        //lets the player respawn if they fall into the void
        transform.position = temp;
        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
        
    }

    //Player jumps
    void Jump()
    {
        //checks to see if the player is on the ground, if so lets player jump. (if above void, no jump)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
            //currentJump = 0;
        }
        else
        {
            isGrounded = false;
        }

        //makes the "space" key let the player jump
        if (Input.GetKey("space"))
        {
            rigid_body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //currentJump++;
        }
    }

    //UI
    void SetCountText()
    {
        coinText.text = "Coins: " + coins.ToString();
        //   if (count >= 11)
        //   {
        //       winText.text = "You Win!";
        //   }

        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            gameOverText.text = "Game Over!";
            GameOverScreen.SetActive(true);//Code added by E.C
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
            coins = coins + 1;
            SetCountText();
        }

        if (other.tag == "Win")
        {
            WinScreen.SetActive(true);
        }

    }

    public void setSpawnPoint(Vector3 newPos)
    {
        startPos = newPos;
    }

   
}