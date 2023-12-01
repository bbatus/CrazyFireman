using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    public float gravityValue = -9.81f;
    public float lookSensitivity = 2f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    private float cameraPitch = 0f; // Dikey (Y ekseni) dönüş için

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Fare imlecini kilitle ve gizle
    }

    void Update()
    {
        if (!controller.enabled)
            return;

        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Hareket
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Zıplama
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -2f * gravityValue); // Doğru zıplama formülü
        }

        // Yerçekimi
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Fare ile bakış yönünü ayarla
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -15f, 20); // Dikey dönüşü sınırla
        transform.localEulerAngles = new Vector3(cameraPitch, transform.localEulerAngles.y + mouseX, 0);
    }
}

