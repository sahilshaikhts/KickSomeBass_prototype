using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class Boat : BaseVehicle, IControllable
{
    Rigidbody m_rigidBody;

    [SerializeField] GameObject m_camera;

    [SerializeField] float m_speed = 5;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    public void Initialize()
    {
        m_camera.SetActive(true);
    }

    public void Deactivate()
    {
        if (m_driver.GetComponent<Rigidbody>())
        {
            m_driver.GetComponent<Rigidbody>().useGravity = true;
        }
        m_driver = null;

        m_camera.SetActive(false);
    }

    public void Move(Vector3 aDirection)
    {
        Vector3 finalVelocity = aDirection.z * transform.forward;

        finalVelocity *= m_speed;

        if (aDirection.x != 0)
        {
            m_rigidBody.MoveRotation(m_rigidBody.rotation * Quaternion.Euler(Vector3.up * aDirection.x));
            m_driver.GetComponent<Rigidbody>().MoveRotation(m_rigidBody.rotation * Quaternion.Euler(Vector3.up * aDirection.x));
        }

        m_rigidBody.velocity = finalVelocity;

        m_driver.transform.position = m_seat.transform.position;

    }

    public void SetRotation(Quaternion aRoatation)
    {
        throw new System.NotImplementedException();
    }

    public BaseCamera GetObjectCamera()
    {
        return m_camera.GetComponent<BaseCamera>();
    }

}
