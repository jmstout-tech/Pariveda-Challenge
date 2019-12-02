using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFootball : MonoBehaviour
{
    void Start()
    {
        
    }

     void Update()
    {
        
    }

    //OnTrigger method allows for the item to be obtainable upon player collision.
     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Player"))
        {
            Destroy(gameObject);
        }
    }
}
