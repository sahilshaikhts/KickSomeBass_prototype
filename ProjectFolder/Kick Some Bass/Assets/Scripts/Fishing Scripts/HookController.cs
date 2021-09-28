using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookController : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    public float DownwardSpeed = 2.0f;
    
    private bool bfishCaught = false;
    private float timer = 2.5f;

    void Update()
    {
        if(!bfishCaught)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, -1.0f, vertical).normalized;
            Vector3 newPosition;

            newPosition.x = direction.x * MovementSpeed * Time.deltaTime;
            newPosition.z = direction.z * MovementSpeed * Time.deltaTime;

            //speed-up
            if (Input.GetKey(KeyCode.LeftShift))
                newPosition.y = direction.y * DownwardSpeed * 2.625f * Time.deltaTime;
            else
                newPosition.y = direction.y * DownwardSpeed * Time.deltaTime;

            transform.position += newPosition;
        }

        if(bfishCaught)
            timer -= Time.deltaTime;

        if (timer <= 0.0f)
            SceneManager.LoadScene("Scene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fish")
        {
            Debug.Log("Fish-Caught");

            if(other.gameObject)
            {
                Destroy(other.gameObject);
                bfishCaught = true;
            }
        }
    }
}
