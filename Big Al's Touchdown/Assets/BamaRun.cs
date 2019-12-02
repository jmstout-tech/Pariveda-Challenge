using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamaRun : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.5f;

    private Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator Animator;

    Vector3 bamapos;

    private Transform Bama_Runner;

    public Transform BamaGoalEnd;

    void Start()
    {
        Animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        Bama_Runner = GameObject.FindGameObjectWithTag("BamaEnd").GetComponent<Transform>();
        bamapos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Bama_Runner.position) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Bama_Runner.position, speed * Time.deltaTime);
            if (transform.position.x < BamaGoalEnd.transform.position.x)
            {
                //enemy is left of the EndGoal, face right
                transform.localScale = new Vector3(-2.138433f, 2.145315f, 1.87805f);
            }
            else if (transform.position.x > BamaGoalEnd.transform.position.x)
            {
                //enemy is right of the EndGoal, face left
                transform.localScale = new Vector3(2.138433f, 2.145315f, 1.87805f);
            }
        }
    }
}

   
