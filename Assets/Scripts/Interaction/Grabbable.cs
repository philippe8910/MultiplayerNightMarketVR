using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(PhotonView), typeof(InteractableHoverEvents))]
public class Grabbable : MonoBehaviour
{
    private InteractableHoverEvents hoverEvents { get => GetComponent<InteractableHoverEvents>();}
    private PhotonView photonView { get => GetComponent<PhotonView>();}


    void Start()
    {
        hoverEvents.onAttachedToHand.AddListener(delegate {
            photonView.RequestOwnership();
            //photonView.RPC("CancelGravityRPC", RpcTarget.All, true);
        });

        hoverEvents.onDetachedFromHand.AddListener(delegate {
            //photonView.RPC("CancelGravityRPC", RpcTarget.All, false);
        });
    }

    [PunRPC]
    public void CancelGravityRPC(bool cancelGravity)
    {
        Debug.Log("Gravity is " + (cancelGravity ? "canceled" : "enabled"));
    }
}
