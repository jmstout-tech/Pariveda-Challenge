using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    private int health = 3;
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    private UnityEngine.Object enemyRef;
    private Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    [SerializeField]
    float delayBeforeDestroy = 5;

    Vector3 startpos;

    private Transform Enemy1;

    public Transform Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startpos = transform.position;
        enemyRef = Resources.Load("Enemy1");
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        explosionRef = Resources.Load("Explosion");

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Enemy1.position) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Enemy1.position, speed * Time.deltaTime);
            if (transform.position.x  < Player.transform.position.x)
            {
                //enemy is left of the player, face right
                transform.localScale = new Vector3(-2.138433f, 2.145315f, 1.87805f);
            }
            else if (transform.position.x > Player.transform.position.x)
            {
                //enemy is right of the player, face left
                transform.localScale = new Vector3(2.138433f, 2.145315f, 1.87805f);
            }
        }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fireball"))
            {
                Destroy(collision.gameObject);
                health--;
                sr.material = matWhite;

                if (health <= 0)
                {
                    KillSelf();
                }
                else
                {
                    Invoke("ResetMaterial", .1f);

                }
            }
        }

        void ResetMaterial()
        {
            sr.material = matDefault;
        }

        private void KillSelf()
        {
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);

            gameObject.SetActive(false);
            Invoke("Respawn", delayBeforeDestroy);

        }

        void Respawn()
        {
            GameObject enemyClone = (GameObject)Instantiate(enemyRef);
        enemyClone.transform.position = transform.position;
            Destroy(gameObject);
        }
    }



        
    


    










