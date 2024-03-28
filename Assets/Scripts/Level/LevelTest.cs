using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class LevelTest : MonoBehaviour, IGameTrigger
{
    public int timeCount {get; set;}
    public int scoreCount {get; set;}
    public bool isGameStart {get; set;}
    public Text timeText {get; set ;}
    public Text scoreText {get; set;}
    public PhotonView photonView {get => GetComponent<PhotonView>(); set => photonView = value;}
    public TeleportPoint teleportPoint {get; set;}

    [PunRPC]
    public void OnGameStart()
    {
        timeCount = 60;
        scoreCount = 0;

        isGameStart = true;

        Debug.Log("Game Start");
    }

    [PunRPC]
    public void OnGameTimeUp()
    {
        timeCount = 0;
        scoreCount = 0;

        isGameStart = false;

        Debug.Log("Game Over");
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.name == "TeleportPoint")
                teleportPoint = child.GetComponent<TeleportPoint>();

            if(child.name == "TimeText")
                timeText = child.GetComponent<Text>();

            if(child.name == "ScoreText")
                scoreText = child.GetComponent<Text>();
        }

        teleportPoint.OnTeleport.AddListener(delegate {
            photonView.RPC("OnGameStart", RpcTarget.All);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStart)
        {
            timeCount -= (int)Time.deltaTime;
            timeText.text = timeCount.ToString();

            if(timeCount <= 0)
            {
                photonView.RPC("OnGameTimeUp", RpcTarget.All);
            }
        }
    }

    [ContextMenu("GameStartRPC")]
    public void GameStartRPC()
    {
        photonView.RPC("OnGameStart", RpcTarget.All);
    }

    [ContextMenu("GameTimeUpRPC")]
    public void GameTimeUpRPC()
    {
        photonView.RPC("OnGameTimeUp", RpcTarget.All);
    }
}
