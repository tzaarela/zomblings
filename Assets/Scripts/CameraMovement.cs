using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float m_CameraSpeed;
    [Range(0,1)]
    public float m_CameraSmoothing = 0.3f;
    private float m_ScreenHeight;
    private void FixedUpdate()
    {
        MoveCamera();
    }

    private void Update()
    {
        m_ScreenHeight = Screen.height;
    }

    private void MoveCamera()
    {

        if (Input.mousePosition.y >= m_ScreenHeight)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.y, transform.position.y + 10, ref m_CameraSpeed, m_CameraSmoothing);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z); 
        }
        else if (Input.mousePosition.y <= -20)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.y, transform.position.y - 10, ref m_CameraSpeed, m_CameraSmoothing);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        }


        //if (transform.position.y > 20)
        //{
        //    transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        //}

        //if (transform.position.y < -40)
        //{
        //    transform.position = new Vector3(transform.position.x, -40, transform.position.z);
        //}
    }
}
