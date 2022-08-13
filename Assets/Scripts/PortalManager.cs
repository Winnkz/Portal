using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform Apos;
    public Transform Bpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal A"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            transform.position = Bpos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, Bpos.rotation.y, transform.rotation.z, transform.rotation.w);
            Debug.Log("A");

            cc.enabled = true;
        }

        if (other.CompareTag("Portal B"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            transform.position = Apos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, Apos.rotation.y, transform.rotation.z, transform.rotation.w);
            Debug.Log("B");

            cc.enabled = true;
        }
    }
}
