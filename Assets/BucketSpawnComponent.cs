using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BucketSpawnComponent : MonoBehaviour
{
    [SerializeField] private GameObject bucketPrefab;
    [SerializeField] private Interactable currentBucket;
    [SerializeField] private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentBucket = PhotonNetwork.Instantiate("CircleComponent", spawnPoint.position, Quaternion.identity).GetComponent<Interactable>();
    }

    void Update()
    {
        if(Vector3.Distance(currentBucket.transform.position, spawnPoint.position) > 0.3f && currentBucket.attachedToHand != null)
        {
            currentBucket = PhotonNetwork.Instantiate("CircleComponent", spawnPoint.position, Quaternion.identity).GetComponent<Interactable>();
        }
    }
}
