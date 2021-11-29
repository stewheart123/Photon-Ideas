using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class AssignPlayer : MonoBehaviourPunCallbacks
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerOneScore;
    public int playerTwoScore;
    [SerializeField] Text playerOneDisplay;
    [SerializeField] Text playerTwoDisplay;    
    public PlayerInput[] players;
    

    public void SetupUI()
    {
        players = FindObjectsOfType<PlayerInput>();

        foreach (PlayerInput player in players)
        {
            if (player.IsPlayerOne)
            {
                playerOne = player.gameObject;
            }
            if (!player.IsPlayerOne)
            {
                playerTwo = player.gameObject;
            }
        }
    }

    void Update()

    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            playerOneDisplay.text = playerOne.GetComponent<PlayerInput>().score.ToString();
            playerOneScore = playerOne.GetComponent<PlayerInput>().score;
            playerTwoDisplay.text = playerTwo.GetComponent<PlayerInput>().score.ToString();
            playerTwoScore = playerTwo.GetComponent<PlayerInput>().score;
        }
    }
}
