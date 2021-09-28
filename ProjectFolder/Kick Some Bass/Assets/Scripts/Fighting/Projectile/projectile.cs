using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private IFighterCharacter m_shooter;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if its fighter
        if (other.GetComponent<projectile>() == true)
        {
            Destroy(gameObject);
        }

        if (other.GetComponent<IFighterCharacter>() == true) 
        {
            Destroy(gameObject);
            other.GetComponent<IFighterCharacter>().ChangeHealth(-10);
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * Time.deltaTime * 300, ForceMode.VelocityChange);

        }
    }

    public void SetShooter(IFighterCharacter shooter)
    {
        m_shooter = shooter;
    }

    public IFighterCharacter GetShooter() { return m_shooter; }

}
