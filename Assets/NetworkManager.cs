using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Network Objects and variables

    [SerializeField] GameObject networkUi;
    private PlayerInput playerInput;


    #endregion

    #region Photon Network Overrides

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();

        if(PhotonNetwork.PlayerList.Length == 1)
        {
            //move this line of code to send if statement later
            PhotonNetwork.Instantiate("Network UI", networkUi.transform.position, networkUi.transform.rotation);
            playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
            playerInput.IsPlayerOne = true;
        }
        if (PhotonNetwork.PlayerList.Length == 2)
        {   
            playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();            
            playerInput.IsPlayerOne = false;
            Debug.Log("this code will not run until P2 is here");

        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player has entered the room!");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to connect to server");
    }
    
    void Update()
    {
        
    }
    #endregion
}
