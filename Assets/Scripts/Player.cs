using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float _moveSpeed, _jumpHeight, camera_sensitivity_x, camera_sensitivity_y;
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
    private Vector2 mouse_input;

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

        playerInputActions.PlayerFPV.Camera_X.performed += ctx => mouse_input.x = ctx.ReadValue<float>();
        playerInputActions.PlayerFPV.Camera_Z.performed += ctx => mouse_input.y = ctx.ReadValue<float>();
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

    private void FPV_Camera_Input()
    {
        if (current_camera_mode == "FPV")
        {
            camera_controller.fpv_rotate_x(mouse_input.x * camera_sensitivity_x * Time.deltaTime);
            fpv_rotate_y(mouse_input.y * camera_sensitivity_y * Time.deltaTime);
        }
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
            Debug.Log("Jump"+context.phase);
            Main_Rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.VelocityChange);
        }
    }
    private void Update()
    {
        isWalking = false;
        Movement_Input(current_camera_mode);
        FPV_Camera_Input();
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
