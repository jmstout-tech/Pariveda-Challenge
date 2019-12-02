using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    //Declare the component to track the player within unity.
    [SerializeField]
    GameObject player;

    [SerializeField]
    float speedOffset;

    [SerializeField]
    Vector2 posOffset;

    
    void Start()
    {
        

    }

    
    void Update()
    {
        
        //Lerping Mechanism
        Vector3 startPos = transform.position;

        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -8;

        transform.position = Vector3.Lerp(startPos, endPos, speedOffset * Time.deltaTime);

        //Statement will track the player dead center without any delay.
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

    }
}

