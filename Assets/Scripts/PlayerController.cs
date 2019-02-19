using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D rb2d;
    public GameObject gameController;
    public Vector2 speed;
    private Vector2 movement;
    public float jumpThrust;
    public bool playerJumped;
    public float maxJumpVelocity = 10f;
    public float hMovement;
    public float vMovement;
    public bool IsFacingRight;
    public bool playerDead;

	// Use this for initialization
	void Start () {
        IsFacingRight = true;
        playerDead = false;
        playerJumped = false;
        gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        if (!playerDead) {
            hMovement = Input.GetAxisRaw("Horizontal");
            vMovement = Input.GetAxisRaw("Vertical");
            //vMovement = rb2d.velocity.y;
            //Debug.Log(rb2d.velocity.y);
            movement = new Vector2(speed.x * hMovement, speed.y * vMovement);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //vMovement = transform.up * jumpThrust;
                playerJumped = true;
                //Debug.Log("JUMPED");
            }
            else {
                //vMovement = 0f;
                //Debug.Log(rb2d.velocity.y);
                //Debug.Log(maxJumpVelocity);
                playerJumped = false;
            }
            if (hMovement > 0f)
            {
                if (!IsFacingRight)
                {
                    IsFacingRight = true;
                    FlipPlayer();
                }
                animator.SetBool("IsRunning", true);
            }
            else if (hMovement < 0f)
            {
                if (IsFacingRight)
                {
                    IsFacingRight = false;
                    FlipPlayer();
                }
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }

            if (playerJumped)
            {
                animator.SetBool("Jumped", true);
            }
            else
            {
                animator.SetBool("Jumped", false);
            }
        }
	}

    void FixedUpdate() {
        if (!playerDead) {
            //hMovement = speed * Input.GetAxisRaw("Horizontal");
            //vMovement = jumpSpeed * Input.GetAxisRaw("Vertical");
            rb2d.velocity = movement;
            // rb2d.velocity = new Vector2((rb2d.velocity.x), vMovement);
            //Debug.Log(rb2d.velocity);
            //vMovement = rb2d.velocity.y * jumpThrust;
            //rb2d.AddForce(new Vector2(transform.position.x, vMovement));
        }
    }

    void FlipPlayer() {
        transform.localScale = new Vector3((transform.localScale.x * -1f), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("COLLISSION HAPPENED");
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            playerDead = true;
            //animator.SetBool("IsDead", true);
            animator.Play("PlayerDead");
            gameController.GetComponent<GameController>().playerLife--;
            Destroy(gameObject, 3.0f);
            gameController.GetComponent<GameController>().SetReSpawnPlayer(true);
        }
        else if (other.gameObject.CompareTag("GameEndLine")) {
            playerDead = true;
            //animator.SetBool("IsDead", true);
            animator.Play("PlayerDead");
            gameController.GetComponent<GameController>().playerLife--;
            Destroy(gameObject, 3.0f);
            gameController.GetComponent<GameController>().SetReSpawnPlayer(true);
        }
    }
}


/*
using UnityEngine;
 
/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
  /// <summary>
  /// 1 - The speed of the ship
  /// </summary>
  public Vector2 speed = new Vector2(50, 50);
 
  // 2 - Store the movement
  private Vector2 movement;
 
  void Update()
  {
    // 3 - Retrieve axis information
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");
 
    // 4 - Movement per direction
    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);
 
  }
 
  void FixedUpdate()
  {
    // 5 - Move the game object
    rigidbody2D.velocity = movement;
  }
}
*/