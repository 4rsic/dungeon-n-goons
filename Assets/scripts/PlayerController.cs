using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private bool shouldFaceMoveDir = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    private PlayerControls playercontrols;

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    private void Awake()
    {
        playercontrols = new PlayerControls();
    
        playercontrols.gameplay.Sprint.performed += x => sprintPress();
        playercontrols.gameplay.Sprint.canceled += x => sprintRelease();

    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("We are supposed to jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public bool isSprinting = false;

    public float sprintSpeed = 1.3f;
    
    private void sprintPress()
    {

        isSprinting = true;

        Debug.Log("We are sprinting!");

    }

    private void sprintRelease()
    {

        isSprinting = false;

        Debug.Log("We are NOT sprinting!");

    }
   

    // Update is called once per frame
    private void Update()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

        

        if (isSprinting)
        {

            controller.Move(moveDirection * (speed * sprintSpeed) * Time.deltaTime);

        }
        else
        {

            controller.Move(moveDirection * speed * Time.deltaTime);

        }
        

        if (shouldFaceMoveDir && moveDirection.sqrMagnitude > 0.001f)
        {

            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f *  Time.deltaTime);

        }

        //Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        //controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
