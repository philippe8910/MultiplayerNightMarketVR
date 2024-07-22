using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SandBagBoxComponent : MonoBehaviour
{
    [SerializeField] private GameObject sandBagPrefab = null;
    [SerializeField] private Interactable currentSandBag = null;
    [SerializeField] private Transform sandBagSpawnPoint = null;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentSandBag = PhotonNetwork.Instantiate("SandBag", sandBagSpawnPoint.position, Quaternion.identity).GetComponent<Interactable>();
    }
    
    void Update()
    {
        if(Vector3.Distance(currentSandBag.transform.position, sandBagSpawnPoint.position) > 0.3f && currentSandBag.attachedToHand != null)
        {
            currentSandBag = PhotonNetwork.Instantiate("SandBag", sandBagSpawnPoint.position, Quaternion.identity).GetComponent<Interactable>();
        }

    }
}
