using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer: MonoBehaviour
{
    //Declares what the timer will start at in the program.
    float currentTime = 0f;
    float startingTime = 300f;

    //Serialize the component to allow the program to display the text canvas for it.
    [SerializeField]
    Text countdownText;
   
    void Start()
    {
        currentTime = startingTime;
    }
  
    void Update()
    {
        //Initiates the timer to countdown by 1 after the program has started.
        currentTime -= 1 * Time.deltaTime;

        //Allows the clock to countdown without displaying decimals, will only countdown as whole numbers.
        countdownText.text = currentTime.ToString("0");


        //If statement that allows the clock to stop when it hits 0 and not fall into the negatives.
        if(currentTime <= 0)
        {
            currentTime = 0;
        }

        //Allows the color to change after a certain timestamp has been met within the program.
        if (currentTime < 3.5f) { countdownText.color = Color.black; }
    }
}



