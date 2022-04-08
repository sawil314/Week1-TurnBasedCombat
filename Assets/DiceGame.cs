using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGame : MonoBehaviour
{
    int playerResult;
    int aiResult;
    int counterRolled = 0;
    // Start is called before the first frame update 
    void Start()
    {
        Debug.Log("Game started");
    }

    // Update is called once per frame
    void Update() 
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && counterRolled<3)
        {
            playerResult = roll();
            Debug.Log(playerResult);
            counterRolled++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && counterRolled > 2)
        {
            Debug.LogWarning("You already rolled three times!");
        }
        else if (Input.GetKeyDown(KeyCode.Return) && counterRolled>0)
        {
            aiResult = roll();
            Debug.Log("AIResult: " + aiResult);
            if (playerResult == aiResult)
            {
                Debug.Log("Tie!");
            }
            else if (playerResult > aiResult)
            {
                Debug.Log("Player wins!");
            }
            else
            {
                Debug.Log("AI wins!");
            }
            counterRolled = 0;
        }
        
        

    }

    int roll()
    {
        int die1 = Random.Range(1, 7);
        int die2 = Random.Range(1, 7);
        int result = die1 + die2;
        return result;
    }
}
