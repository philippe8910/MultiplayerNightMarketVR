using Photon.Pun;
using UnityEngine;

public class VRBodySetting : MonoBehaviour
{
    [SerializeField] private bool isComputer;
    public PhotonView photonView;
    public GameObject avatar , playerPos;
    public Transform HMD, headModelPos;
    public Transform rightHandControllerPos, rightHandModelPos;
    public Transform leftHandControllerPos, leftHandModelPos;
    
    private void Start()
    {
        avatar = transform.GetChild(0).gameObject;
        if (photonView.IsMine)
        {
            avatar.SetActive(false);
            playerPos = GameObject.FindGameObjectWithTag("Player");
            if (!isComputer)
            {
                rightHandControllerPos = GameObject.Find("RightHand").transform;
                leftHandControllerPos = GameObject.Find("LeftHand").transform;  
                HMD = Camera.main.transform; 
            }
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        transform.position = playerPos.transform.position;

        rightHandModelPos.position = rightHandControllerPos.position;
        rightHandModelPos.rotation = rightHandControllerPos.rotation;

        leftHandModelPos.position = leftHandControllerPos.position;
        leftHandModelPos.rotation = leftHandControllerPos.rotation;

        headModelPos.position = HMD.position;
        headModelPos.rotation = HMD.rotation;
        //Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
    }
}
