using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform head;
    //public Transform hand;
    public float Speed = 10f;
    public float JumpForce = 300f;
    public float rotationSpeed = 2.0f;
    public float jumpSpeed = 15.0f;
    public float gravity = 30.0f;
    public float maxHeadRotation = 80.0f;
    public float minHeadRotation = -80.0f;

    private float health = 100.0f;
    private bool _isGrounded;
    private CharacterController characterController;
    private float currentHeadRotation = 0;
    private Animator m_Animator;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        MovementLogic();

    }
    private void Update()
    {
        MouseRotation();
        
    }

    private void MouseRotation()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

        //head.Rotate(Vector3.left, mouseInput.y * rotationSpeed);
        currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);

        head.localRotation = Quaternion.identity;
        head.Rotate(Vector3.left, currentHeadRotation);

    }
    private void MovementLogic()
    {
        
        
        if (characterController.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsWalking", isWalking);
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        

    }

   

    
}
