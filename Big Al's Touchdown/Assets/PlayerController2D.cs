using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Object fireballRef;
    Object fireballRef2;
    Object Football;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    public AudioSource Jump;

    public AudioClip FireballSound;

    bool isGrounded;
    bool isShooting;

    bool FacingLeft = false;
    bool FacingRight = true;

    float shootAnimationDelay = 0.4f;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float runSpeed = 4f;

    [SerializeField]
    private float jumpSpeed = 6f;

    [SerializeField]
    private int health = 5;

    private Material matWhite;
    private Material matDefault;


    void Start()
    {
        //Initiates the Components to function within the program and be declared within the script.
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;

    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            animator.Play("Player_shoot");
            isShooting = true;
            Invoke("ResetShoot", shootAnimationDelay);
            if (FacingRight)
            {
                fireballRef = Resources.Load("Fireball");
                GameObject fireball = (GameObject)Instantiate(fireballRef);
                AudioSource.PlayClipAtPoint(FireballSound, new Vector3(transform.position.x, transform.position.y, -7));
                fireball.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .4f, -4);
            }

            if (FacingLeft)
            {
                fireballRef2 = Resources.Load("Fireball2");
                GameObject fireball2 = (GameObject)Instantiate(fireballRef2);
                AudioSource.PlayClipAtPoint(FireballSound, new Vector3(transform.position.x, transform.position.y, -7));
                fireball2.transform.position = new Vector3(transform.position.x - .4f, transform.position.y + .4f, -4);
            }
        }
    }

    private void FixedUpdate()
    {
        //Allows the animation effects to trigger once condition has been met.
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //Allows the user to move right. Vector2 x coordinate determines how fast the user can move once key is implemented. Also triggers the run animation.
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(4, rb2d.velocity.y);

            if (isGrounded)
                animator.Play("Player_run");

            spriteRenderer.flipX = false;

            FacingRight = true;
            FacingLeft = false;
        }
        //Allows the user to move left. Vector2 x coordinate determines how fast the user can move once key is implemeneted. Also triggers the run animation.
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-4, rb2d.velocity.y);

            if (isGrounded)
                animator.Play("Player_run");

            spriteRenderer.flipX = true;

            FacingRight = false;
            FacingLeft = true;
        }
        else
        //Initiates the idle animation if no activity is detected through the user input. 
        {
            if (isGrounded && !isShooting)
                animator.Play("Player_idle");

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        //Allows the user to jump. Vector2 y coordinate determines how high the user is able to jump. Also initiates the jump animation.
        if (Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 6);
            animator.Play("Player_jump");
            Jump.Play(); 
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(Football, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Enemy"))
        {
            health--;
            spriteRenderer.material = matWhite;

            if (health <= 0)
            {
                SceneManager.LoadScene("Title Screen");
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
            if (col.gameObject.CompareTag("Finish"))
            {
                SceneManager.LoadScene("EndScene");
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }

        void ResetShoot()
        {
            isShooting = false;

        }
    }





        

        
    


