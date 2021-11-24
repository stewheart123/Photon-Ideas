using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPlayer : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerOneScore;
    public int playerTwoScore;
    [SerializeField] Text playerOneDisplay;
    [SerializeField] Text playerTwoDisplay;    
    public PlayerInput player;
    
    void Start()
    {   
        player = FindObjectOfType<PlayerInput>();
        Debug.Log("player is player one " + player.IsPlayerOne);
        if (player.IsPlayerOne)
        {
            playerOne = player.gameObject;
        }
        else
        {
            playerTwo = player.gameObject;
        }
        

    }

    void Update()
    {
        if (playerOne)
        {
            playerOneDisplay.text = playerOne.GetComponent<PlayerInput>().score.ToString();
        }
        if (playerTwo)
        {
            playerTwoDisplay.text = playerTwo.GetComponent<PlayerInput>().score.ToString();
        }
        
    }
}
