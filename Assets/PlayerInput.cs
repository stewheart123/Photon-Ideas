using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsPlayerOne;
    public int score;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            Debug.Log("button pressed");          
        }
    }
}
