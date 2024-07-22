using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class InteractionNetwork : MonoBehaviour
{
    public Throwable throwable;
    public Rigidbody rigidbody;
    public PhotonView photonView;
    public PhotonTransformView photonTransformView;
    // Start is called before the first frame update
    void Start()
    {
        throwable = GetComponent<Throwable>();
        rigidbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
        photonTransformView = GetComponent<PhotonTransformView>();

        rigidbody.useGravity = false;
        photonTransformView.m_UseLocal = false;
    

        throwable.onPickUp.AddListener(delegate {
            photonView.RequestOwnership();
            //photonView.RPC("CancelGravityRPC", RpcTarget.All, true);
        });

        throwable.onDetachFromHand.AddListener(delegate {
            //photonView.RPC("CancelGravityRPC", RpcTarget.All, false);
        });
    }
}
