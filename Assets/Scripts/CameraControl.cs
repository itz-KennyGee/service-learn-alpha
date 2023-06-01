using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Transform armsT;
    [SerializeField] private Transform bodyT;
    private float xRotationCap;


    private void Start()
    {
        CursorLock();
    }
    private void Update()
    {
        MouseLookHandler();
    }

    private void MouseLookHandler()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotationCap -= mouseY;
        xRotationCap = Mathf.Clamp(xRotationCap, -90, 90);

        armsT.localRotation = Quaternion.Euler(new Vector3(xRotationCap, 0, 0));
        bodyT.Rotate(new Vector3(0, mouseX, 0));
    }

    private void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
