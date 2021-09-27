using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCameraController : MonoBehaviour
{
    [SerializeField] GameObject m_Camera;
    [SerializeField] Transform m_player;
    [SerializeField] Transform m_opponent;

    [SerializeField] Vector3 m_offset;


    void Start()
    {
        //TODO:- Move this line to levelManager's that will switch between different modes based on game's state along with setting m_player and m_opponent 
        Cursor.lockState = CursorLockMode.Locked;
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
        Vector3 offset = new Vector3(0, -10, 0);
        m_Camera.transform.rotation = Quaternion.LookRotation(m_player.transform.forward - m_player.transform.right*1.5f);

        m_Camera.transform.position = CalculateCameraPosition()+transform.forward*2;
    }

    void CalculateZoomDistance()
    {
        Vector2 playerViewport = Camera.main.WorldToViewportPoint(m_player.position);
        Vector2 opponenetViewport = Camera.main.WorldToViewportPoint(m_opponent.position);

        float viewportDistance = Vector2.Distance(playerViewport, opponenetViewport);

    }
}

