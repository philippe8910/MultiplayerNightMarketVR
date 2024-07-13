using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class SandBagGroupComponent : MonoBehaviour
{
    public SandBagComponent[] sandBagTargets;


    // Start is called before the first frame update
    void Start()
    {
        sandBagTargets = transform.GetComponentsInChildren<SandBagComponent>();
        StartCoroutine(StartDetected());
    }

    IEnumerator StartDetected()
    {
        yield return new WaitForSeconds(1);

        foreach (SandBagComponent sandBag in sandBagTargets)
        {
            if(sandBag.GetIsTriggered())
            {
                StartCoroutine(StopDetected());
            }
        }

        StartCoroutine(StartDetected());
    }

    IEnumerator StopDetected()
    {
        yield return new WaitForSeconds(3);

        StartCoroutine(StartDetected());

        ResetAllSandBags();
    }

    private void ResetAllSandBags()
    {
        foreach (SandBagComponent sandBag in sandBagTargets)
        {
            sandBag.Reset();
        }
    }
}
