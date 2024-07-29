using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public class BalloonComponent : MonoBehaviour
{
    public GameObject effectPrefab;

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    public async void OnCollisionEnter(Collision other)
    {
        var effect = PhotonNetwork.Instantiate(effectPrefab.name, transform.position, Quaternion.identity);

        PhotonNetwork.Destroy(gameObject);
        Destroy(other.gameObject);
        
        await Task.Delay(1000);
        PhotonNetwork.Destroy(effect);
    }
}
