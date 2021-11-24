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
    public PlayerInput[] players;
    
    void Start()
    {   
        players = FindObjectsOfType<PlayerInput>();
        
        foreach(PlayerInput player in players)
        {
            if (player.IsPlayerOne)
            {
                playerOne = player.gameObject;
            }
            else
            {
                playerTwo = player.gameObject;
            }
        }

    }

    void Update()
    {
     
            playerOneDisplay.text = playerOne.GetComponent<PlayerInput>().score.ToString();
            playerOneScore = playerOne.GetComponent<PlayerInput>().score;
            playerTwoDisplay.text = playerTwo.GetComponent<PlayerInput>().score.ToString();
            playerTwoScore = playerTwo.GetComponent<PlayerInput>().score;
       
        
    }
}
