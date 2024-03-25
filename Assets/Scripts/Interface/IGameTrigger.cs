using Photon.Pun;

public interface IGameTrigger
{
    int timeCount { get; set; }
    int scoreCount { get; set; }
    PhotonView photonView {get; set;}

    void OnGameStart();
    void OnGameTimeUp();
    void OnGameOver();
}