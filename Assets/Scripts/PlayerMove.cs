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
    private float multiplierSpeed;
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private Camera not_camera;

    [SerializeField]
    private CharacterController charController;

    private const float GRAVITY = -9.81f;
    private bool isShift = false;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isShift = true;
        }
        if (Math.Abs(not_camera.transform.rotation.eulerAngles.x - Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse Y") - 180) > 90)
        {
            not_camera.transform.Rotate(-Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse Y"), 0, 0);
        }
        transform.Rotate(0, Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse X"), 0);

        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xPos + transform.forward * zPos;

        charController.Move(move.normalized * speed * Time.fixedDeltaTime * (isShift ? multiplierSpeed : 1f));

        charController.Move(new Vector3(0, GRAVITY, 0) * Time.fixedDeltaTime);

        //gameObject.transform.Translate(new Vector3(xPos, 0, zPos) * speed * Time.fixedDeltaTime * (isShift? multiplierSpeed : 1f));
        isShift = false;
    }
}
