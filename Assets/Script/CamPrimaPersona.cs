using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CamPrimaPersona : MonoBehaviour
{
    public bool CanMove {get; private set; } = true ; 
    [Header("Movement Parameters")]
    [SerializeField] private float walkspeed = 200.0f;
    [SerializeField] private float gravity= 30.0f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 6.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 6.0f;
    [SerializeField, Range (1,180)] private float upperlooklimit = 80.0f;
    [SerializeField, Range (1,180)] private float lowerlooklimit = 80.0f;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;
    void Start()
    {
       playerCamera = GetComponentInChildren <Camera>();
       characterController = GetComponent<CharacterController> ();
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    
    void Update()
    {
        if (CanMove) {
            HandleMovementInput();
            HandleMouseLook();

            ApplyFinalMovements ();
        }
    }
        private  void HandleMovementInput(){
            
            currentInput = new Vector2(walkspeed * Input.GetAxis("Vertical"), walkspeed * Input.GetAxis("Horizontal"));
            float moveDirectionY = moveDirection.y;
            moveDirection= (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
            moveDirection.y = moveDirectionY;
        }
        private void HandleMouseLook () {
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
            rotationX = Mathf.Clamp(rotationX, -upperlooklimit, lowerlooklimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler (0, Input.GetAxis("Mouse X")  * lookSpeedX, 0);


        }
        private void ApplyFinalMovements () {

            if(!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection  * Time.deltaTime);
        }
    }


