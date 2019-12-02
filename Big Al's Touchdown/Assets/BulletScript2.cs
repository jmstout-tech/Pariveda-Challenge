using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Start()
    {     
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", .5f);
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(-10, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        { 
            Destroy(gameObject);
        }
    }

   private void DestroySelf()
   {     
           Destroy(gameObject);       
   }
}








    





































