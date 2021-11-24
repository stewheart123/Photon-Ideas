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


    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            //havent done anything apart from assign this variable;
            LocalPlayerInstance = this.gameObject;
            if (PhotonNetwork.PlayerList.Length == 1)
            {
                IsPlayerOne = true;
            }
            else
            {
                IsPlayerOne = false;
            }
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
