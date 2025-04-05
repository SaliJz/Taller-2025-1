using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float verticalClamp = 85f;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale == 0) return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotación vertical (eje X)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalClamp, verticalClamp);
        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0f);

        // Rotación horizontal (eje Y) — gira el cuerpo del jugador
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}