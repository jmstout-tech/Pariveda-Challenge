using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    //Script is Offline from Alpha.

        //Beta version while include scoring system incremented via TMPro format.

    //UI namespace required in order to display ScoringSystem Text on the screen. Also declaring variables within the program.
    public GameObject scoreText;
    public static int theScore;
    
     void Update()
    {      
        //Updates the score once collectable object has been obtained. 
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;      
    }
}
