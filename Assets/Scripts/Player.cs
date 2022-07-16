using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool impostor;
    private bool onGround;
    public Camera cam_side;
    public Camera cam_fpv;
    public float _moveSpeed;
    public float _jumpHeight;
    private Animator animator;
    //private List <GameObject> currentCollisions = new List <GameObject> ();
    private int floor_counter;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetBool("onGround", false);
        onGround = false;
        floor_counter = 0;
    }
    
     void Update()
    {
        animator.SetBool("isWalking", false); // стоит улучшить механизм определения с помощью нажатия/отжатия клавиш 
        animator.SetBool("onGround", onGround);

        if (Input.GetKey(KeyCode.D) & Camera.main == cam_side)
        {
            animator.SetBool("isWalking", true);
            transform.position += Time.deltaTime * _moveSpeed * Vector3.right; //движение будет привязано к частоте кадров
        } 

        if (Input.GetKey(KeyCode.A) & Camera.main == cam_side)
        {   
            animator.SetBool("isWalking", true);
            transform.position += Time.deltaTime * _moveSpeed * Vector3.left;
        } 

        if (Input.GetKey(KeyCode.W) & Camera.main == cam_fpv)
        {
            animator.SetBool("isWalking", true);
            transform.position += Time.deltaTime * _moveSpeed * Vector3.right; //движение будет привязано к частоте кадров
        } 

        if (Input.GetKey(KeyCode.S) & Camera.main == cam_fpv)
        {   
            animator.SetBool("isWalking", true);
            transform.position += Time.deltaTime * _moveSpeed * Vector3.left;
        } 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            if (onGround)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpHeight, ForceMode.VelocityChange);
            }
        
        }

    }    
     
    void OnCollisionEnter (Collision collision) 
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
 
     void OnCollisionExit (Collision collision)
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
