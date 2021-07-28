using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    public float speed = 1f;
    public Transform cam;
    public float sensitivity;
    float rotation = 0f;
    float rotationLimit = 90f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        LookAround();
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxisRaw("Vertical");
        float z = Input.GetAxisRaw("Horizontal");

        Vector3 moveBy = transform.forward * x + transform.right * z;

        body.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);
    }

    private void LookAround()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.Rotate(0f, x, 0f);

        rotation = rotation + y;
        rotation = Mathf.Clamp(rotation, -rotationLimit, rotationLimit);
        cam.localEulerAngles = new Vector3(rotation, 0f, 0f);
    }
}
