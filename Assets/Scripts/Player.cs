using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Camera cam_side;
    public Camera cam_fpv;
    public float _moveSpeed;
    public float _jumpHeight;
    private Animator animator;
    private bool impostor;
    private bool onGround;
    private bool isWalking;
    private int floor_counter;
    //private List <GameObject> currentCollisions = new List <GameObject> ();
    private Rigidbody Main_Rigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetBool("onGround", false);
        onGround = false;
        isWalking = false;
        floor_counter = 0;
        Main_Rigidbody = GetComponent<Rigidbody>();
        
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Playerside.Enable();
        playerInputActions.Playerside.Jump.performed += Jump; // может сделать .started
        //playerInputActions.Playerside.Movement.canceled += Movement_End;

    }
    
    private void Change_Camera(Camera main_camera)
    {
        if (main_camera == cam_side)
        {
            playerInputActions.Playerside.Enable();
        }
        else if (main_camera == cam_fpv)
        {
            playerInputActions.PlayerFPV.Enable();
        }
    }

    private bool Walk(Vector2 inputVector)
    {
        inputVector.Normalize();
        if (inputVector.x !=  0 | inputVector.y !=  0) // стоит ли использовать .Equals() ?
        {
            Debug.Log(inputVector);
            transform.position += Time.deltaTime * _moveSpeed * new Vector3(inputVector.y, 0, -inputVector.x); //движение будет привязано к частоте кадров
            return true;
        }
        else
        {
            return false;
        } 
        
    }
    private void Movement_Input(Camera main_camera)
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (main_camera == cam_side)
        {
            inputVector = playerInputActions.Playerside.Movement.ReadValue<Vector2>(); // возвращает нормализованный вектор
        }
        else if (main_camera == cam_fpv)
        {
            inputVector = playerInputActions.PlayerFPV.Movement.ReadValue<Vector2>();
        }

        isWalking = Walk(inputVector); // потом придется переделать если добавлю бег
    }

    private void Movement_End(InputAction.CallbackContext context)
    {
        isWalking = false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (onGround)
        {
            Debug.Log("Jump"+context.phase);
            Main_Rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.VelocityChange);
        }
    }
    private void Update()
    {
        Change_Camera(Camera.main);
        isWalking = false;
        Movement_Input(Camera.main); // стоит поменять на current
        animator.SetBool("isWalking", isWalking); 
        animator.SetBool("onGround", onGround);
    }    
     
    private void OnCollisionEnter (Collision collision) // дискретно работает, может багануть
    {
        if (collision.gameObject.tag == "Floor")
        {
            floor_counter++;
        }
        
        if (floor_counter == 0){
            onGround = false;
        }
        else{
            onGround = true;
        }
    }
 
    private void OnCollisionExit (Collision collision)
     {
        if (collision.gameObject.tag == "Floor")
        {
            floor_counter--;
        }

        if (floor_counter == 0){
            onGround = false;
        }
        else{
            onGround = true;
        }
    }

}
