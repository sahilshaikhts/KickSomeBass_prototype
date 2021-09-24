using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;


public class TPCamera : BaseCamera
{
    [SerializeField]
    float xRot = 0, yRot = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateMouseInput();

        ShootRayFromScreenCenter();
    }
    private void FixedUpdate()
    {
        UpdateRotations();
    }

    void UpdateRotations()
    {
        transform.rotation = Quaternion.Euler(yRot, xRot, 0);
        transform.position = m_target.transform.position;

        if(!m_lockTargetObjectrotation)
            m_target.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, xRot, 0);
    }

    void UpdateMouseInput()
    {
        xRot += Input.GetAxis("Mouse X") * 5;

        yRot -= Input.GetAxis("Mouse Y") * 5;
        yRot = Mathf.Clamp(yRot, -20, 50);
    }

}
