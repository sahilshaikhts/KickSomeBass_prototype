using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;
public class Humanoid : MonoBehaviour, IControllable
{
    Rigidbody m_rigidBody;
    
    [SerializeField] GameObject m_camera;

    [SerializeField]float m_speed=5;
    
    
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
        m_camera.SetActive(false);
    }

    public void Move(Vector3 aDirection)
    {
        Vector3 finalVelocity=aDirection.x*transform.right+aDirection.z*transform.forward;
        RaycastHit hit_groundNormalCheck;

        Ray ray_groundNormalCheck = new Ray(transform.position, Vector3.down * 100);
        finalVelocity *= m_speed;

        if (Physics.Raycast(ray_groundNormalCheck, out hit_groundNormalCheck))
        {
            if (hit_groundNormalCheck.normal.y < 1)
            {
                finalVelocity.y = m_rigidBody.velocity.y - hit_groundNormalCheck.normal.normalized.y;
            }
            else
            {
                finalVelocity.y = m_rigidBody.velocity.y;
            }
        }
        m_rigidBody.velocity = finalVelocity;
    }

    public void SetRotation(Quaternion aRoatation)
    {
        throw new System.NotImplementedException();
    }

    public BaseCamera GetObjectCamera()
    {
        return  m_camera.GetComponent<BaseCamera>();
    }
}
