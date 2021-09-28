using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 14f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check if its fighter 
        if(other.GetComponent<projectile>()==true)
        {
            Destroy(gameObject);
        }

        if (other.GetComponent<IFighterCharacter>()==true)
        {
            other.GetComponent<IFighterCharacter>().ChangeHealth(-10);
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * Time.deltaTime * 600, ForceMode.VelocityChange);
            Destroy(gameObject);
        }
    }
}
