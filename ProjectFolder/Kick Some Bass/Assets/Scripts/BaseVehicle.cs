using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class BaseVehicle : MonoBehaviour
{
    [SerializeField] protected GameObject m_seat;
    protected GameObject m_driver;


    public void Initialize(GameObject aDriver)
    {
        if(GetComponent<IControllable>()!=null)
        {
            GetComponent<IControllable>().Initialize();
        }
        m_driver = aDriver;

        if (m_driver.GetComponent<Rigidbody>())
        {
            m_driver.GetComponent<Rigidbody>().useGravity = false;
        }

        m_driver.transform.position = m_seat.transform.position;

    }

}
