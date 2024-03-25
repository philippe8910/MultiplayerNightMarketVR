using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(PhotonView), typeof(Throwable) , typeof(PhotonTransformView))]
public class Grabbable : MonoBehaviour
{
    public PhotonView photonView { get => GetComponent<PhotonView>();}
    public Throwable throwable { get => GetComponent<Throwable>();}
    public Rigidbody rb { get => GetComponent<Rigidbody>();}

    void Start()
    {
        throwable.onPickUp.AddListener(delegate {
            photonView.RequestOwnership();
            rb.useGravity = false;
        });

        throwable.onDetachFromHand.AddListener(delegate {
            rb.useGravity = true;
        });
    }
}
