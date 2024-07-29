using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public class SandBagCollisionComponent : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    public GameObject effect;


    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    async void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("SandBagTrigger"))
        {
            audioSource.Play();
            var ef = PhotonNetwork.Instantiate(effect.name, transform.position, Quaternion.identity);
            
            await Task.Delay(2000);

            PhotonNetwork.Destroy(gameObject);
            PhotonNetwork.Destroy(ef);
            
        }
    }
}
