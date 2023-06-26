using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float zoomSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float padding;
    private Vector2 mousePos;
    Vector3 moveDir;
    private float zoomScroll;

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.unscaledDeltaTime, Space.World);
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.unscaledDeltaTime, Space.World);

        if (transform.position.x < -40) transform.position = new Vector3(-40, transform.position.y, transform.position.z);
        else if (transform.position.x > 72) transform.position = new Vector3(72, transform.position.y, transform.position.z);

        if (transform.position.z < -95) transform.position = new Vector3(transform.position.x, transform.position.y, -95);
        else if (transform.position.z > -50) transform.position = new Vector3(transform.position.x, transform.position.y, -50);
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnPointer(InputValue value)
    {
        mousePos = value.Get<Vector2>();
        if (mousePos.x <= padding)
        {
            moveDir.x = -1;
        }
        else if (mousePos.x >= Screen.width - padding)
        {
            moveDir.x = 1;
        }
        else
            moveDir.x = 0;

        if (mousePos.y <= padding)
        {
            moveDir.y = -1;
        }
        else if (mousePos.y >= Screen.height - padding)
        {
            moveDir.y = 1;
        }
        else
            moveDir.y = 0;
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime, Space.Self);
        if (transform.position.y < 12) transform.position = new Vector3(transform.position.x, 12, transform.position.z);
        else if(transform.position.y > 42) transform.position = new Vector3(transform.position.x, 42, transform.position.z);
    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;

    }
}
