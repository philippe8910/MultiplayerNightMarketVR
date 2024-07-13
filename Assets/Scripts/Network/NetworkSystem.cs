using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkSystem : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text logText;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("NetworkSystem");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        logText.text = "Connected to Master";
        Debug.Log("OnConnectedToMaster");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        //todo: create room

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Room", roomOptions, TypedLobby.Default);

        logText.text = "Joined Lobby";
        Debug.Log("OnJoinedLobby");        
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        logText.text = "Joined Room";
        Debug.Log("OnJoinedRoom");

        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            PhotonNetwork.LoadLevel("Level");
            logText.text = "Load Game Scene";
            Debug.Log("Load Game Scene");
        }   
    }
}
