using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed = 4.0f;
    [SerializeField] private float sprintSpeed = 6.0f;

    [SerializeField] private float gravity = -13f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;


    private bool isCrouching = false;

    [SerializeField] private bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;


    void Start()
    {
        controller = GetComponent<CharacterController>();


        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();

    }

    void UpdateMouseLook()
    {
        Vector2 targedMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));


        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targedMouseDelta, ref currentMouseDeltaVelocity, moveSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);

    }

    void UpdateMovement()
    {

        Vector2 targetDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
            //jump
            if (Input.GetKeyDown("space"))
            {
                velocityY = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
            //sprint
            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

       //     if (Input.GetKey(KeyCode.C))
        //    {
        //        controller.height = 1.0f;
         //       isCrouching = true;
          //  }
           // else {
        //        controller.height = 1.8f;
        //        isCrouching = false;
         //   }
        }



        //Apply Gravity
        velocityY += gravity * Time.deltaTime;
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * moveSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

}