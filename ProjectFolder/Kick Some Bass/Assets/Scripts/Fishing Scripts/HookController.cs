using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float MovementSpeed = 1.0f;
    float velocity;

    int i = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

       // if(horizontal > 0.001f || horizontal < 0.001f)
        {
            Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;
            transform.position += direction * MovementSpeed * Time.deltaTime;

            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float smoothTargetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocity, 0.75f);
                transform.rotation = Quaternion.Euler(0, smoothTargetAngle, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fish")
        {
            i++;
            Debug.Log("Fish-Caught " + i);
            Destroy(other.gameObject);
        }
    }
}
