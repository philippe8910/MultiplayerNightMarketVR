using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlcieTest : MonoBehaviour, IDamageable
{
    public int DamageCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Action OnDestroyed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    void Start()
    {
        
    }

    public void TakeDamage(int amount)
    {
        DamageCount -= amount;

        if(DamageCount <= 0)
        {
            OnDestroyed();
        }
    }
}
