using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerInput : MonoBehaviour
{
    public bool IsPlayerOne;
    public int score;
    private PhotonView photonView;
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;
    private AssignPlayer assignPlayer;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

            if (PhotonNetwork.PlayerList.Length == 1)
            {
                IsPlayerOne = true;
            }
            if(PhotonNetwork.PlayerList.Length ==2)
            {
                IsPlayerOne = false;
                assignPlayer = GameObject.FindObjectOfType<AssignPlayer>();
                assignPlayer.SetupUI();
            }
            
    }

    void Update()
    {
        if (  photonView.IsMine && Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            Debug.Log("button pressed");          
        }
    }
}
