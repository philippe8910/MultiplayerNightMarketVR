using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BowNetworkInteraction : MonoBehaviour
{
    public Animator animator;
    public ItemPackageSpawner itemPackageSpawner;

    void Start()
    {
        itemPackageSpawner = GetComponent<ItemPackageSpawner>();

        itemPackageSpawner.pickupEvent.AddListener(delegate {
            animator.SetBool("Grab", true);
        });

        itemPackageSpawner.dropEvent.AddListener(delegate {
            animator.SetBool("Grab", false);
        });
    }

    void Update()
    {
        if(animator == null)
        {
            var g = GameObject.FindGameObjectsWithTag("Avatar");

        Debug.Log("Found " + g.Length + " avatars");

        foreach (var item in g)
        {
            if (item.GetComponent<PhotonView>().IsMine)
            {
                animator = item.GetComponent<Animator>();
            }
        }
        }
    }
}
