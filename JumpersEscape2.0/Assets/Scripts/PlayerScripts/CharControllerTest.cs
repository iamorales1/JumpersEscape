using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControllerTest : MonoBehaviour
{
    public static CharControllerTest instance;
    public int countdownTime;
    public GameObject Jumper = null;
    // Transform coinEffect;
    // [SerializeField]
    // private GameObject ParticlePrefab;
    public GameOver GameOver;
    int maxTokens = 0;

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
    private int count;
    public int lives = 3;
    public int fallDepth;
    public bool isGrounded;
    //private const int maxJump = 2;
    //private int currentJump = 0;
    private Vector3 startPos;
    public Text winText;
    public Text countText;
    public Text livesText;
    public Text gameOverText;
    // internal static object instance;


    //////
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight;
    private float _gravImpulse;
    public bool gameplaying { get; private set; }

    private bool canDoubleJump;
    private bool canWallJump;
    private Vector3 wallNormal;
    private Vector3 velocity;

    private CharacterController _charController;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        SetCountText();
        StartCoroutine(CountdownToStart());

        //gameplaying = false;
        // BeginGame();
    }

    public void BeginGame()
    {
        gameplaying = true;
        //startTime = Time.time;
    }


    void Update()
    {

       // StartCoroutine(CountdownToStart());

        if (countdownTime > 0)
        {
            return;
        }

        Debug.Log("Player Move");


       // if (!_charController.enabled)
           // return;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horInput, 0, vertInput);
        velocity = dir * _speed;


        if (_charController.isGrounded)
        {
            Debug.Log("Ground");
            // Vector3 dir = new Vector3(horInput, 0, vertInput);
            // velocity = dir * _speed;
            canWallJump = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {

                _gravImpulse = _jumpHeight;
                canDoubleJump = true;
            }
        }
        else
        {
            _gravImpulse -= _gravity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canWallJump)
                {
                    _gravImpulse = _jumpHeight;
                    velocity = wallNormal * _speed;
                    canWallJump = false;
                    canDoubleJump = false;
                }
                else if (canDoubleJump)
                {
                    _gravImpulse += _jumpHeight;
                    canDoubleJump = false;
                }

            }
        }
        velocity.y = _gravImpulse;
        _charController.Move(velocity * Time.deltaTime);

        


        if (transform.position.y < fallDepth)
        {
            
            Respawn();
            lives--;

        }

    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!_charController.isGrounded && hit.collider.CompareTag("Wall"))
        {
            wallNormal = hit.normal;
            canWallJump = true;
            Debug.Log("Wall jump triggered");
        }
    }



    public void Respawn()
    {
        Debug.Log("Dead");
        transform.position = startPos;
        //lives--;
        SetCountText();
        if (lives <= 0)
        {
            this.enabled = false;
        }



    }

    void SetCountText()
    {
        countText.text = "Tokens: " + maxTokens.ToString();
        //   if (count >= 11)
        //   {
        //       winText.text = "You Win!";
        //   }

        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            //gameOverText.text = "Game Over!";
            GameOverScreen();
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
            //  Instantiate(ParticlePrefab, gameObject.transform.position, Quaternion.identity);
            maxTokens++;
            SetCountText();
        }
        if (other.tag == "Win")
        {
           winText.text = "You Win!";
        }
    }



    public void setSpawnPoint(Vector3 newPos)
    {
        startPos = newPos;
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            // countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            Jumper.SetActive(true);
            countdownTime--;
        }


    }

    public void GameOverScreen()
    {
        GameOver.Setup(maxTokens);
    }

   

}