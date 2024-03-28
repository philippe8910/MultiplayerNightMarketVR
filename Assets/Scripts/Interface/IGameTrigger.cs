using Photon.Pun;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public interface IGameTrigger
{
    int timeCount { get; set; }
    int scoreCount { get; set; }

    bool isGameStart { get; set; }

    Text timeText { get; set; }
    Text scoreText { get; set; }
    PhotonView photonView {get; set;}

    TeleportPoint teleportPoint { get; set; }

    void OnGameStart();
    void OnGameTimeUp();
}