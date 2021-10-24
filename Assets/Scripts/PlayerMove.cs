using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private Camera not_camera;
    private void FixedUpdate()
    {

        if (Math.Abs(not_camera.transform.rotation.eulerAngles.x - Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse Y") - 180) > 90)
        {
            not_camera.transform.Rotate(-Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse Y"), 0, 0);
        }
        transform.Rotate(0, Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse X"), 0);

        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");

        gameObject.transform.Translate(new Vector3(xPos, 0, zPos) * speed * Time.fixedDeltaTime);
    }
}
