using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCameraController : MonoBehaviour
{
    [SerializeField] GameObject m_Camera;
    [SerializeField] Transform m_player;
    [SerializeField] Transform m_opponent;

    [SerializeField] float min_xRot = 0, max_xRot = 0;

    [SerializeField] Vector3 m_offset;


    float xRot = 0, yRot = 0;

    float zDistance;

    void Start()
    {
        //TODO:- Move this line to levelManager's that will switch between different modes based on game's state along with setting m_player and m_opponent 
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateMouseInput();
    }
    private void LateUpdate()
    {
        CalculateZoomDistance();
        PositionCamera();
    }

    Vector3 CalculateCameraPosition()
    {
        Bounds camBound = new Bounds();
        if (m_player.position.y > -2)
        {
            camBound.Encapsulate(m_player.position * 2);
        }
        else
        if (m_opponent.position.y > -2)
        {
            camBound.Encapsulate(m_opponent.position);
        }
        else
        {
            camBound.Encapsulate(Vector3.one);
        }
        return camBound.center;
    }

    void PositionCamera()
    {
        m_Camera.transform.rotation = m_player.GetComponent<Rigidbody>().rotation;

        m_Camera.transform.position = CalculateCameraPosition() + m_offset;
    }

    void CalculateZoomDistance()
    {
        Vector2 playerViewport = Camera.main.WorldToViewportPoint(m_player.position);
        Vector2 opponenetViewport = Camera.main.WorldToViewportPoint(m_opponent.position);

        float viewportDistance = Vector2.Distance(playerViewport, opponenetViewport);

    }


    void UpdateMouseInput()
    {
        xRot += Input.GetAxis("Mouse X") * 3;

        yRot -= Input.GetAxis("Mouse Y") * 5;
        yRot = Mathf.Clamp(yRot, min_xRot, max_xRot);
    }

}

