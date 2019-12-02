using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    //Script is Offline from Alpha.

        //Beta version while utilize better components for AI Tracking including air units.
    
    public float speed;

    private Transform Enemy1;
    // Start is called before the first frame update
    void Start()
    {
        Enemy1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, Enemy1.position) > -7) 
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemy1.position, speed * Time.deltaTime);
        }
    }
}
    
