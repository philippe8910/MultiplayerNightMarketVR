using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SandBagComponent : MonoBehaviour
{
    private bool isTriggered = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SandBag"))
        {
            isTriggered = true;
        }
    }

    public bool GetIsTriggered()
    {
        return isTriggered;
    }

    public void Reset()
    {
        isTriggered = false;
        transform.DOMove(originalPosition, 1f);
        transform.DORotateQuaternion(originalRotation, 1f);
    }
}
