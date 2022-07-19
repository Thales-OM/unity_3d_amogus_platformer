using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    public float _moveSpeed, _jumpHeight, camera_speed_x, camera_speed_y, camera_sensitivity_x, camera_sensitivity_y;
    public GameObject Main_Body, Hands;
    public Camera_Controller camera_controller;
    private Animator animator;
    //private Camera cam_side, cam_fpv;
    private bool onGround, isWalking;
    private int floor_counter;
    //private List <GameObject> currentCollisions = new List <GameObject> ();
    private Rigidbody Main_Rigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private SkinnedMeshRenderer[] Main_Body_Meshes;
    private string current_camera_mode;
    private Dictionary<string, dynamic> mode_to_map;
    private Vector2 mouse_movement;
    private bool camera_x_performed, camera_y_performed;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetBool("onGround", false);
        onGround = false;
        isWalking = false;
        floor_counter = 0;
        current_camera_mode = "Side";
        Main_Rigidbody = GetComponent<Rigidbody>();
        Main_Body_Meshes = Main_Body.GetComponentsInChildren<SkinnedMeshRenderer>();
        //cam_side = camera_controller.cam_side; // выглядит ненадежно, передаем public поля как константы для последующего сравнения
        //cam_fpv = camera_controller.cam_fpv;
        
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.Playerside.Enable();
        playerInputActions.PlayerFPV.Disable();

        playerInputActions.Playerside.Jump.performed += Jump; // может сделать .started
        playerInputActions.PlayerFPV.Jump.performed += Jump; //выглядит грязновато, можно перевести в отдельный метод, но переводить в Update() не стоит
        
        //playerInputActions.Playerside.Movement.canceled += Movement_End;

        playerInputActions.Playerside.Change_Camera.performed += call_camera_switch; // может сделать .started
        playerInputActions.PlayerFPV.Change_Camera.performed += call_camera_switch;

        camera_x_performed = false; 
        camera_y_performed = false;
        mouse_movement = new Vector2(0, 0);

        playerInputActions.PlayerFPV.Camera_X.performed += ctx => mouse_movement.x = ctx.ReadValue<float>();
        playerInputActions.PlayerFPV.Camera_X.performed += set => camera_x_performed = true;
        playerInputActions.PlayerFPV.Camera_Y.performed += ctx => mouse_movement.y = ctx.ReadValue<float>();
        playerInputActions.PlayerFPV.Camera_Y.performed += set => camera_y_performed = true;

        mode_to_map = new Dictionary<string, dynamic> {{ "Side", playerInputActions.Playerside }, { "FPV", playerInputActions.PlayerFPV }};// можно ввести абстракцию для обращения к мапу, но стоит ли??
    }
    private void call_camera_switch(InputAction.CallbackContext context)
    {
        camera_controller.Switch();
    }
    public void Set_Camera_Mode(string new_camera_mode)
    {
        if (new_camera_mode == "Side" | new_camera_mode == "FPV")
        {
            current_camera_mode = new_camera_mode;
            Switch_Input_Map(new_camera_mode);
            Switch_Player_Model(new_camera_mode);
        }
    }
    private UnityEngine.Rendering.ShadowCastingMode switch_model_render(UnityEngine.Rendering.ShadowCastingMode last_state)
    {
        if (last_state == UnityEngine.Rendering.ShadowCastingMode.On)
        {
            return UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //думаю можно как-то локально хранить чтобы не вызывать каждый раз
        }
        else
        {
            return UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }
    private bool Switch_Player_Model(string current_camera_mode)
    {
        if (current_camera_mode == "Side")
        {
            foreach (SkinnedMeshRenderer mesh in Main_Body_Meshes)
            {
                mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
            Hands.SetActive(false);
            return true;
        }
        else if (current_camera_mode == "FPV")
        {   
            Hands.SetActive(true);
            foreach (SkinnedMeshRenderer mesh in Main_Body_Meshes)
            {
                mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            return true;
        }
        return false;
    }
    private void Switch_Player_Model()
    {
        Hands.SetActive(!Hands.activeSelf); //аттрибут показывает активность независимо от родительского объекта, может показать true при еактивном родителе
        foreach (SkinnedMeshRenderer mesh in Main_Body_Meshes)
        {
            mesh.shadowCastingMode = switch_model_render(mesh.shadowCastingMode); //звучит неэффективно при большем числе детей
        }
    }
    private void Switch_Input_Map(string current_camera_mode)
    {
        if (current_camera_mode == "Side")
        {
            playerInputActions.Playerside.Enable();
            playerInputActions.PlayerFPV.Disable();
        }
        else if (current_camera_mode == "FPV")
        {
            playerInputActions.Playerside.Disable();
            playerInputActions.PlayerFPV.Enable();
        }
    }

    private void Dash()
    {
        
    }

    private bool Walk(Vector2 inputVector)
    {
        inputVector.Normalize();
        if (inputVector.x !=  0 | inputVector.y !=  0) // стоит ли использовать .Equals() ?
        {
            //Debug.Log(inputVector);
            //transform.position += Time.deltaTime * _moveSpeed * new Vector3(inputVector.y, 0, -inputVector.x); //движение будет привязано к частоте кадров
            transform.Translate(Time.deltaTime * _moveSpeed * new Vector3(inputVector.x, 0, inputVector.y));
            return true;
        }
        else
        {
            return false;
        }  
    }
    private void Movement_Input(string current_camera_mode)
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (current_camera_mode == "Side")
        {
            inputVector = playerInputActions.Playerside.Movement.ReadValue<Vector2>(); // возвращает нормализованный вектор
        }
        else if (current_camera_mode == "FPV")
        {
            inputVector = playerInputActions.PlayerFPV.Movement.ReadValue<Vector2>();
        }

        isWalking = Walk(inputVector); // потом придется переделать если добавлю бег
    }

    private Vector2 Camera_Sensitivity(Vector2 inputVector)
    {   
        Vector2 outputVector = new Vector2(0, 0);
        if (Math.Abs(inputVector.x) >= camera_sensitivity_x)
        {
            outputVector.x = inputVector.x;
        }

        if (Math.Abs(inputVector.y) >= camera_sensitivity_y)
        {
            outputVector.y = inputVector.y;
        }
        return outputVector;
    }
    private void FPV_Camera_Input(Vector2 camera_input)
    {
        if (current_camera_mode == "FPV")
        {   
            Debug.Log(camera_input);
            camera_controller.fpv_rotate_x(camera_input.x * camera_speed_x * Time.deltaTime);
            fpv_rotate_y(camera_input.y * camera_speed_y * Time.deltaTime);
        }
    }

    /*private Vector2 Check_Camera_Movement(Vector2 camera_input) //может не передавать а менять
    {
        Vector2 outputVector = new Vector2(0, 0);
        if (playerInputActions.PlayerFPV.Camera_X.WasPerformedThisFrame())
        {
            outputVector.x = camera_input.x;
        }
        if (playerInputActions.PlayerFPV.Camera_Y.WasPerformedThisFrame())
        {
            outputVector.y = camera_input.y;
        }
        return outputVector;
    }*/

    private Vector2 Check_Camera_Movement(bool camera_x_performed, bool camera_y_performed, Vector2 camera_input) //может не передавать а менять
    {
        Vector2 outputVector = new Vector2(0, 0);
        if (camera_x_performed)
        {
            outputVector.x = camera_input.x;
        }
        if (camera_y_performed)
        {
            outputVector.y = camera_input.y;
        }
        return outputVector;
    }

    public void fpv_rotate_y(float degrees)
    {   
        transform.Rotate(0.0f, degrees, 0.0f);
    }
    private void Movement_End(InputAction.CallbackContext context)
    {
        isWalking = false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (onGround)
        {
            //Debug.Log("Jump"+context.phase);
            Main_Rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.VelocityChange);
        }
    }
    private void Update()
    {
        isWalking = false;
        Movement_Input(current_camera_mode);
        FPV_Camera_Input(Camera_Sensitivity(Check_Camera_Movement(camera_x_performed, camera_y_performed, mouse_movement)));
        //FPV_Camera_Input(Camera_Sensitivity(Mouse_Movement(ref mouse_last_position, mouse_current_position)));
        animator.SetBool("isWalking", isWalking); 
        animator.SetBool("onGround", onGround);

        //контролирует что мышь была сдвинута и InputSystem не передает старый вектор
        camera_x_performed = false;
        camera_y_performed = false;
    }    

    /*private Vector2 Mouse_Movement(ref Vector2 mouse_last_position, Vector2 mouse_current_position)
    {
        Vector2 mouse_movement = mouse_current_position - mouse_last_position;
        mouse_last_position = mouse_current_position;
        return mouse_movement;
    }
    */
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
