using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveWithLaunch : MonoBehaviour
{
    public Transform playerCamera;
    public float sensitivity = 200f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseXMove);

        Vector3 currentCameraXRotation = playerCamera.transform.localEulerAngles;
        if (currentCameraXRotation.y >= 180 && currentCameraXRotation.x > 90.0f)
        {
            playerCamera.localEulerAngles = new Vector3(-90f, 0f, 0f);
        }
        else if (currentCameraXRotation.y >= 180 && currentCameraXRotation.x < 270.0f)
        {
            playerCamera.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
        else
        {
            playerCamera.Rotate(new Vector3(Mathf.Clamp(-mouseYMove, -90, 90), 0f, 0f), Space.Self);
        }
    }

    public void LaunchPlayer() {
        playerVelocity.y += Mathf.Sqrt((jumpHeight * 3.0f) * -3.0f * gravityValue);
    }
}
