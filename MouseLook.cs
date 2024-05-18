using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    void Start()
    {
        m_camera = Camera.main;  // Don't keep calling Camera.main
    }

    void Update()
    {
        var lookAtPos = Input.mousePosition;
        lookAtPos.z = m_camera.transform.position.y - transform.position.y;
        lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
        transform.forward = lookAtPos - transform.position;
    }

    Camera m_camera;
}