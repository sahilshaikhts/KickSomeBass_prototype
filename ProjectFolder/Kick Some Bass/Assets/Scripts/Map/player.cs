using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class player : MonoBehaviour
{
    GameObject m_objectBeingControlled;

    [SerializeField] GameObject m_Humanoid;

    Vector3 move_direction;
    
    private void Start()
    {
        m_objectBeingControlled = GameObject.FindWithTag("Humanoid");
        m_objectBeingControlled.GetComponent<IControllable>().Initialize();

        if (m_objectBeingControlled==null)
        {
            Debug.LogError("No inital controlable object set");
        }
    }

    private void Update()
    {
        InteractInput();

        move_direction = (transform.forward * Input.GetAxis("Vertical") + (transform.right * Input.GetAxis("Horizontal")));
    }

    void FixedUpdate()
    {
        m_objectBeingControlled.BroadcastMessage("Move", move_direction);
    }

    void InteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj_inFront = m_objectBeingControlled.GetComponent<IControllable>().GetObjectCamera().GetComponent<BaseCamera>().GetGameObjectInFront();
        
            if (obj_inFront && obj_inFront != gameObject)
            {
                if (Vector3.Distance(obj_inFront.transform.position, m_objectBeingControlled.transform.position) < 15)
                {
                    if (obj_inFront.GetComponent<IControllable>() != null)
                    {
                        if (obj_inFront.GetComponent<BaseVehicle>() != null)
                        {
                            m_objectBeingControlled.GetComponent<IControllable>().Deactivate();
                            obj_inFront.GetComponent<BaseVehicle>().Initialize(m_objectBeingControlled);

                            m_objectBeingControlled = obj_inFront;
                        }
                        else
                        {
                            //if it's not a vehicle
                            m_objectBeingControlled.GetComponent<IControllable>().Deactivate();
                            obj_inFront.GetComponent<IControllable>().Initialize();

                            m_objectBeingControlled = obj_inFront;
                        }
                    }

                    
                }
            }
       
        }

        //Temporary ,to exit boat
        if (m_objectBeingControlled!=m_Humanoid && Input.GetKeyDown(KeyCode.F))
        {
            m_objectBeingControlled.GetComponent<IControllable>().Deactivate();
            m_Humanoid.GetComponent<IControllable>().Initialize();

            m_objectBeingControlled = m_Humanoid;
            m_Humanoid.transform.position = m_objectBeingControlled.GetComponent<IControllable>().GetObjectCamera().GetComponent<BaseCamera>().GetHitInfoOfRay().point;
        }

    }

    void InteractInputt()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj_inFront = m_objectBeingControlled.GetComponent<IControllable>().GetObjectCamera().GetComponent<BaseCamera>().GetGameObjectInFront();

            if (obj_inFront && obj_inFront != gameObject)
            {
                if (Vector3.Distance(obj_inFront.transform.position, m_objectBeingControlled.transform.position) < 15)
                {
                    if (obj_inFront.GetComponent<IControllable>() != null)
                    {
                        if (obj_inFront.GetComponent<BaseVehicle>() != null)
                        {
                            m_objectBeingControlled.GetComponent<IControllable>().Deactivate();
                            obj_inFront.GetComponent<BaseVehicle>().Initialize(m_objectBeingControlled);

                            m_objectBeingControlled = obj_inFront;
                        }
                        else
                        {
                            //if it's not a vehicle
                            m_objectBeingControlled.GetComponent<IControllable>().Deactivate();
                            obj_inFront.GetComponent<IControllable>().Initialize();

                            m_objectBeingControlled = obj_inFront;
                        }
                    }


                }
            }

        }

        //Temporary ,to exit boat
        if (m_objectBeingControlled != m_Humanoid && Input.GetKeyDown(KeyCode.F))
        {
            m_objectBeingControlled.GetComponent<IControllable>().Deactivate();
            m_Humanoid.GetComponent<IControllable>().Initialize();

            m_objectBeingControlled = m_Humanoid;
            m_Humanoid.transform.position = m_objectBeingControlled.GetComponent<IControllable>().GetObjectCamera().GetComponent<BaseCamera>().GetHitInfoOfRay().point;
        }

    }


  
}
