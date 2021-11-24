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

    private void Start()
    {
        photonView = GetComponent<PhotonView>();        
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
