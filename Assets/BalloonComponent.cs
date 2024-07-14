using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonComponent : MonoBehaviour
{
    public GameObject effectPrefab;

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        var effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
        Destroy(effect, 2f);
    }
}
