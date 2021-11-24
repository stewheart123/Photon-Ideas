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
        
        PhotonNetwork.Instantiate("Player", new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        if (PhotonNetwork.PlayerList.Length == 2)
        {
            PhotonNetwork.Instantiate("Network UI", networkUi.transform.position, networkUi.transform.rotation);            
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
