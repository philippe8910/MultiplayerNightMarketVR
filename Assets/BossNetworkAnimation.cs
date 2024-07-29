using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNetworkAnimation : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("No Animator found on " + gameObject.name);
            return;
        }
        
        
        StartCoroutine(RandomAnimtor());

        IEnumerator RandomAnimtor()
        {
            int index = Random.Range(0, 4);

            anim.SetInteger("ID" , index);

            yield return new WaitForSeconds(3);
            StartCoroutine(RandomAnimtor());
        }
    }
}
