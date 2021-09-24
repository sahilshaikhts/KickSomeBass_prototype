using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCamera : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_target;
    
    [SerializeField] protected bool m_lockTargetObjectrotation;

    protected RaycastHit m_ray_interaction;

    protected void ShootRayFromScreenCenter()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Physics.Raycast(ray, out m_ray_interaction);
    }

    public GameObject GetGameObjectInFront() { return m_ray_interaction.collider.gameObject; }
    public RaycastHit GetHitInfoOfRay() { return m_ray_interaction; }
}
