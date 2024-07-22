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

        StartCoroutine(StartDetecting());
    }

    IEnumerator StartDetecting()
    {
        yield return new WaitForSeconds(1f);

        if(currentBucket.attachedToHand != null && Vector3.Distance(currentBucket.attachedToHand.transform.position, spawnPoint.position) > 1f)
        {
            currentBucket = PhotonNetwork.Instantiate("CircleComponent", spawnPoint.position, Quaternion.identity).GetComponent<Interactable>();
        }
    }
}
